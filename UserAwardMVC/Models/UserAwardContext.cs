using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UserAwardMVC.Models
{
    public class UserAwardContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<UserAward> UserAwards { get; set; }
    }
}