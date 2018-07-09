using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace UserAwardMVC.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }
        //public Image Photo { get; set; }
    }
}