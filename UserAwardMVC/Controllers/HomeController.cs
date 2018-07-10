using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserAwardMVC.Util;

namespace UserAwardMVC.Controllers
{
    public class HomeController : Controller
    {
        private OlympicsEntities1 db = new OlympicsEntities1();

        //[HttpGet]
        //public ActionResult Rewarding(int id)
        //{
        //    ViewBag.UserId = id;
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Rewarding(Award award, UserAward userAward)
        //{ 
        //    userAward.AwardId = award.AwardId;

        //    database.Awards.Add(award);
        //    database.UserAwards.Add(userAward);

        //    database.SaveChanges();

        //    return Redirect("/Home/Users");
        //}

        //public ActionResult Users()
        //{
        //    IEnumerable<User> users = database.Users;
        //    ViewBag.Users = users;
        //    return View();
        //}


        public ActionResult Index(string action)
        {
            if (action == "Users")
            {
                return Redirect("Users/Index");
            }
            if (action == "Award")
            {
                return Redirect("Awards/Index");
            }
            if (action == "File")
            {
                return GetFile();
            }
            return View();
        }

        //public ActionResult GetHtml()
        //{
        //    string path = "../Images/visualstudio.png";
        //    return new HtmlResult("<h2>Здарова!<h2>", path);
        //}

        public FileResult GetFile()
        {
            WriteFile();
            // Путь к файлу
            string file_path = Server.MapPath("~/Files/text.txt");
            // Тип файла - content-type
            string file_type = "application/pdf/txt";
            // Имя файла - необязательно
            string file_name = "text.txt";
            return File(file_path, file_type, file_name);
        }

        private void WriteFile()
        {
            string file_path = Server.MapPath("~/Files/text.txt");

            using (StreamWriter file = new StreamWriter(file_path, false, System.Text.Encoding.Default))
            {

                foreach (var item in db.Users.ToList())
                {
                    file.WriteLine($"User {item.Name} with ID: {item.id_user} was born in {item.Birthday.Year}.{item.Birthday.Month}.{item.Birthday.Day}. His age is {item.Age}");
                }
            }
        }

        //public ActionResult AddUser()
        //{
        //    User user = new User();

        //    return View(user);
        //}

        //[HttpPost]
        //public ActionResult AddUser(User user, HttpPostedFileBase photo1)
        //{
        //    var database = new OlympicsEntities1();

        //    if (photo1 != null)
        //    {
        //        user.UserPhoto = new byte[photo1.ContentLength];
        //        photo1.InputStream.Read(user.UserPhoto, 0, photo1.ContentLength);
        //    }

        //    if ((user.Name is string))
        //    {
        //        database.Users.Add(user);

        //        database.SaveChanges();
        //    }

        //    return View(user);
        //}

        //[HttpPost]
        //public ActionResult Action(string id, string action)
        //{
        //    if (action == "Users")
        //    {

        //    }
        //    if(action == "Rewarding")
        //    {


        //    }
        //    else
        //    {

        //    }
        //}

    }
}