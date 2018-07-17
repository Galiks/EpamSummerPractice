using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TryMVC.Controllers
{
    public class HomeController : Controller
    {
        private OlympicsEntities1 db = new OlympicsEntities1();

        // GET: Home
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

        public FileResult GetFile()
        {
            WriteFile();
            // Путь к файлу
            string file_path = Server.MapPath("~/Files/user'sList.txt");
            // Тип файла - content-type
            string file_type = "application/pdf/txt";
            // Имя файла - необязательно
            string file_name = "user'sList.txt";
            return File(file_path, file_type, file_name);
        }

        private void WriteFile()
        {
            string file_path = Server.MapPath("~/Files/user'sList.txt");

            using (StreamWriter file = new StreamWriter(file_path, false, System.Text.Encoding.Default))
            {

                foreach (var item in db.Users.ToList())
                {
                    file.WriteLine($"User {item.Name} with ID: {item.id_user} was born in {item.Birthday.Year}.{item.Birthday.Month}.{item.Birthday.Day}. His age is {item.Age}");
                }
            }
        }
    }
}