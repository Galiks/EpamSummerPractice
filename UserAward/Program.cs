using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAward.BLL.Container;

namespace UserAward
{
    class Program
    {
        static void Main(string[] args)
        {
            var userLogic = UserAwardContainer.UserLogic;
            var awardLogic = UserAwardContainer.AwardLogic;

            #region testForUser
            //userLogic.AddUser("Petr", "1996-12-04");

            //userLogic.AddUser("John", "1996-12-04");

            //userLogic.AddUser("Alice", "1996-12-04");
            //userLogic.AddUser("Alice", "1800-12-05");
            //userLogic.AddUser("Alice", "1900-12-06");

            //userLogic.AddUser("Papashapa", "1890-10-09");

            //foreach (var item in userLogic.GetUsers())
            //{
            //    Console.WriteLine($"{item.IdUser} : {item.Name}");
            //}

            //Console.WriteLine();

            //userLogic.UpdateUser(4, "Pasha", "1985-07-23");


            //foreach (var item in userLogic.GetUsers())
            //{
            //    Console.WriteLine($"{item.IdUser} : {item.Name}");
            //}

            //Console.WriteLine();

            //userLogic.DeleteUser(7);

            //foreach (var item in userLogic.GetUsers())
            //{
            //    Console.WriteLine($"{item.IdUser} : {item.Name}");
            //} 
            #endregion

            #region testForAward
            //awardLogic.AddAward("Bad Boy", "Bob Marley");
            //awardLogic.AddAward("Good Boy", "For nothing");
            //awardLogic.AddAward("Neutral Boy", null);

            //Console.Write("TITLE: ");
            //var title = Console.ReadLine();
            //Console.WriteLine();
            //Console.Write("DESC: ");
            //var desc = Console.ReadLine();

            //awardLogic.AddAward(title, desc);

            //awardLogic.AddAward("Yellow Boy", null);

            //foreach (var item in awardLogic.GetAwards())
            //{
            //    Console.WriteLine($"{item.IdAward} : {item.Title} : {item.Description}");
            //}

            //Console.WriteLine();

            //foreach (var item in awardLogic.GetAwardByTitle("bad Boy"))
            //{
            //    Console.WriteLine(item.Title);
            //}

            //foreach (var item in awardLogic.GetAwardByWord("y"))
            //{
            //    Console.WriteLine($"{item.Title}");
            //}

            //foreach (var item in awardLogic.GetAwardByLetter('G'))
            //{
            //    Console.WriteLine($"{item.IdAward} : {item.Title}");
            //}

            //Console.WriteLine(awardLogic.GetAwardById(1).Title);

            //awardLogic.DeleteAward(6);

            //foreach (var item in awardLogic.GetAwards())
            //{
            //    Console.WriteLine($"{item.IdAward} : {item.Title} : {item.Description}");
            //}
            #endregion

            #region testForRewarding
            //foreach (var item in awardLogic.GetAwards())
            //{
            //    Console.WriteLine($"{item.IdAward} : {item.Title} : {item.Description}");
            //}

            //Console.WriteLine();

            //foreach (var item in userLogic.GetUsers())
            //{
            //    Console.WriteLine($"{item.IdUser} : {item.Name} : {item.Age}");
            //}

            //userLogic.Rewarding(1, 1);
            //userLogic.Rewarding(1, 2);

            var user = userLogic.GetUserById(1);

            Console.WriteLine($"User {user.Name} have awards: ");
            foreach (var item in userLogic.GetAwardFromUserAward(user))
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }



            Console.WriteLine();
            #endregion

            Console.ReadKey();
        }
    }
}
