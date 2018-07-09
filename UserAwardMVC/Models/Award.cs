using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace UserAwardMVC.Models
{
    public class Award
    {
        public int AwardId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        //public List<int> UserList { get; set; }
        //public Image Photo { get; set; }
    }
}