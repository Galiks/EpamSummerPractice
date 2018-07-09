using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserAwardMVC.Models;

namespace UserAwardMVC.Controllers
{
    public class HomeController : Controller
    {
        UserAwardContext database = new UserAwardContext();

        [HttpGet]
        public ActionResult Rewarding(int id)
        {
            ViewBag.UserId = id;
            return View();
        }

        [HttpPost]
        public string Rewarding(Award award, UserAward userAward)
        { 
            userAward.AwardId = award.AwardId;

            database.Awards.Add(award);
            database.UserAwards.Add(userAward);

            database.SaveChanges();

            return $"Наградите победителя: {userAward.UserId}";
        }

        public ActionResult Index()
        {
            IEnumerable<User> users = database.Users;
            ViewBag.Users = users;
            return View();
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Your contact page.";

        //    return View();
        //}
    }
}