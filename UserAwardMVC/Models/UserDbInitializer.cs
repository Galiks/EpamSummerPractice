using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UserAwardMVC.Models
{
    public class UserDbInitializer: DropCreateDatabaseAlways<UserAwardContext>
    {
        protected override void Seed(UserAwardContext context)
        {
            context.Users.Add(new User { Name = "Pasha", Birthday = DateTime.Parse("1996-12-04"), Age = 21 });
            context.Users.Add(new User { Name = "Alice", Birthday = DateTime.Parse("1996-12-04"), Age = 21 });

            context.Awards.Add(new Award { Title = "Good Boy", Description = "For nothing" });
            context.Awards.Add(new Award { Title = "Bad Boy", Description = "Bob Marley" });

            base.Seed(context);
        }
    }
}