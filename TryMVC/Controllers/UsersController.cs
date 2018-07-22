using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TryMVC;

namespace TryMVC.Controllers
{
    public class UsersController : Controller
    {
        private OlympicsEntities1 db = new OlympicsEntities1();

        // GET: Users
        public ActionResult Index(string searchString = null)
        {

            if (String.IsNullOrEmpty(searchString))
            {
                return View(db.Users.ToList());
            }
            else
            {
                List<User> users = new List<User>();

                if (Char.TryParse(searchString, out char search))
                {
                    List<GetUserByLetter_Result> result = db.GetUserByLetter(searchString).ToList();

                    foreach (var item in result)
                    {
                        users.Add(new User
                        {
                            id_user = item.id_user,
                            Name = item.Name,
                            Birthday = item.Birthday,
                            Age = item.Age,
                            UserPhoto = item.UserPhoto,
                        });
                    }
                    return View(users);
                }
                else
                {
                    List<GetUserByWord_Result> result = db.GetUserByWord(searchString).ToList();
                    foreach (var item in result)
                    {
                        users.Add(new User
                        {
                            Name = item.Name,
                            Birthday = item.Birthday,
                            Age = item.Age,
                            UserPhoto = item.UserPhoto,
                        });
                    }
                    return View(users);
                }
            }
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Birthday")] User user, HttpPostedFileBase image)
        {
            if (ModelState.IsValid && image != null)
            {

                byte[] imageData = null;

                using (var binaryReader = new BinaryReader(image.InputStream))
                {
                    imageData = binaryReader.ReadBytes(image.ContentLength);
                }

                user.UserPhoto = imageData;

                user.Age = SetAge(user.Birthday);

                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            if (ModelState.IsValid && image == null)
            {
                user.UserPhoto = null;

                user.Age = SetAge(user.Birthday);

                db.Users.Add(user);
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    return View(user);
                }
            }
            else
            {
                return View(user);
            }


        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,Birthday")] User user, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    byte[] imageData = null;

                    using (var binaryReader = new BinaryReader(image.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(image.ContentLength);
                    }

                    user.UserPhoto = imageData;

                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                if (image == null)
                {
                    user.UserPhoto = null;

                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult Rewarding(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            ViewBag.UserId = id;

            SelectList awards = new SelectList(db.Awards, "id_award", "Title");
            ViewBag.Awards = awards;

            return View(user);
        }

        [HttpPost]
        public ActionResult Rewarding(Award award, User_Award user_Award, User user)
        {
            if (ModelState.IsValid)
            {
                if (db.Awards.Find(award.id_award) != null)
                {
                    user_Award.id_award = award.id_award;
                    user_Award.id_user = user.id_user;

                    db.User_Award.Add(user_Award);

                    db.SaveChanges();


                    return RedirectToAction("Index");
                }
            }

            return View(user);
        }

        [HttpGet]
        public ActionResult ShowAwards(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            List<GetAwardFromUser_Award_Result> awards = db.GetAwardFromUser_Award(user.id_user).ToList();

            return View(awards);
        }

        public ActionResult SortUsers(string searchString = null)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                List<User> users = new List<User>();


                List<GetUserByName_Result> result = db.GetUserByName(searchString).ToList();

                foreach (var item in result)
                {
                    users.Add(new User
                    {
                        id_user = item.id_user,
                        Name = item.Name,
                        Birthday = item.Birthday,
                        Age = item.Age,
                        UserPhoto = item.UserPhoto,
                    });
                }
                return View(users);
            }
            return View(db.Users.ToList());
        }

        private int SetAge(DateTime birthday)
        {
            if (DateTime.Today.Month > birthday.Month)
            {
                return (DateTime.Today.Year - birthday.Year);
            }
            else
            {
                return (DateTime.Today.Year - birthday.Year) - 1;
            }
        }
    }
}
