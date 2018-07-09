using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserAwardMVC.Models
{
    public class UserAward
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AwardId { get; set; }
    }
}