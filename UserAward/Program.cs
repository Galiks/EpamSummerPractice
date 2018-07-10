using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAward.BLL.Container;
using UserAward.BLL.Interface;
using UserAward.BLL.Logic;

namespace userAward
{
    class Program
    {

        private static IUserLogic userLogic = UserAwardContainer.UserLogic;
        private static IAwardLogic awardLogic = UserAwardContainer.AwardLogic;


        static void Main(string[] args)
        {
            //var userLogic = userAwardContainer.userLogic;
            //var awardLogic = userAwardContainer.AwardLogic;

            #region testForuser
            //userLogic.Adduser("Petr", "1996-12-04");

            //userLogic.Adduser("John", "1996-12-04");

            //userLogic.Adduser("Alice", "1996-12-04");
            //userLogic.Adduser("Alice", "1800-12-05");
            //userLogic.Adduser("Alice", "1900-12-06");

            //userLogic.Adduser("Papashapa", "1890-10-09");

            //foreach (var item in userLogic.Getusers())
            //{
            //    Console.WriteLine($"{item.Iduser} : {item.Name}");
            //}

            //Console.WriteLine();

            //userLogic.Updateuser(4, "Pasha", "1985-07-23");


            //foreach (var item in userLogic.Getusers())
            //{
            //    Console.WriteLine($"{item.Iduser} : {item.Name}");
            //}

            //Console.WriteLine();

            //userLogic.Deleteuser(7);

            //foreach (var item in userLogic.Getusers())
            //{
            //    Console.WriteLine($"{item.Iduser} : {item.Name}");
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

            //foreach (var item in userLogic.Getusers())
            //{
            //    Console.WriteLine($"{item.Iduser} : {item.Name} : {item.Age}");
            //}

            //userLogic.Rewarding(1, 1);
            //userLogic.Rewarding(1, 2);

            //var user = userLogic.GetuserById(1);

            //Console.WriteLine($"user {user.Name} have awards: ");
            //foreach (var item in userLogic.GetAwardFromuserAward(user))
            //{
            //    Console.WriteLine($"{item.Key} : {item.Value}");
            //}



            //Console.WriteLine();
            #endregion

            StartMethod();

        }

        private static void StartMethod()
        {
            
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"1: Add data in base");
                Console.WriteLine($"2: Show data in base");
                Console.WriteLine($"3: Another actions");
                Console.WriteLine($"4: EXIT");

                Console.Write($"Choose action: ");

                var userAction = Console.ReadLine();

                switch (userAction)
                {
                    case "1":
                        Adding();
                        break;
                    case "2":
                        Showing();
                        break;
                    case "3":
                        Actions();
                        break;
                    case "4":
                        return;
                    default:
                        break;
                }
            }
        }

        //добавление информации
        private static void Adding()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"1: Add user");
                Console.WriteLine($"2: Add award");
                Console.WriteLine($"3: Rewarding");
                Console.WriteLine($"4: HELP");
                Console.WriteLine($"5: EXIT");

                Console.Write($"Choose action: ");

                var userAction = Console.ReadLine();

                switch (userAction)
                {
                    case "1":
                        Console.Write($"User's Name: ");
                        var name = Console.ReadLine();
                        Console.Write($"User's Birthday: ");
                        var birthday = Console.ReadLine();
                        if (userLogic.AddUser(name, birthday))
                        {
                            Console.WriteLine($"User is created!{Environment.NewLine}");
                        }
                        else
                        {
                            Console.WriteLine($"User isn't created!{Environment.NewLine}");
                        }
                        break;
                    case "2":
                        Console.Write($"Award's Title: ");
                        var title = Console.ReadLine();
                        Console.Write($"Award's Description: ");
                        var description = Console.ReadLine();
                        awardLogic.AddAward(title, description);
                        Console.WriteLine($"Award is created!{Environment.NewLine}");
                        break;
                    case "3":
                        Console.Write($"User's ID: ");
                        var id_user = Console.ReadLine();
                        Console.Write($"Award's ID: ");
                        var id_award = Console.ReadLine();

                        if (!userLogic.Rewarding(id_user, id_award))
                        {
                            Console.WriteLine($"Ligament isn't created! You are repeat award!{Environment.NewLine}");
                        }
                        else
                        {
                            Console.WriteLine($"Ligament is created!{Environment.NewLine}");
                        }
                        break;
                    case "4":
                        Console.WriteLine($"HELP YOURSELF");
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("I don't know this comuserd");
                        break;
                }
            }
        }

        //показывает информацию
        private static void Showing()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"1: Show all men");
                Console.WriteLine($"2: Show all awards");
                Console.WriteLine($"3: Show all User's award by id");
                Console.WriteLine($"4: EXIT");

                Console.Write($"Choose action: ");

                var userAction = Console.ReadLine();

                switch (userAction)
                {
                    case "1":
                        var men = userLogic.GetUsers();
                        if (men.ToList().Count == 0)
                        {
                            Console.WriteLine($"DB has no information");
                        }
                        else
                        {
                            foreach (var item in men)
                            {
                                Console.WriteLine($"{item.IdUser} : {item.Name} : {item.Birthday.Year}-{item.Birthday.Month}-{item.Birthday.Day} : {item.Age}{Environment.NewLine}");
                            }
                        }
                        break;
                    case "2":
                        var awards = awardLogic.GetAwards();
                        if (awards.ToList().Count == 0)
                        {
                            Console.WriteLine($"DB has no information");
                        }
                        else
                        {
                            foreach (var item in awards)
                            {
                                Console.WriteLine($"{item.IdAward} : {item.Title} : {item.Description}{Environment.NewLine}");
                            }
                        }
                        break;
                    case "3":
                        Console.Write($"User's id: ");
                        var id_3 = Console.ReadLine();
                        var user_3 = userLogic.GetUserById(Int32.Parse(id_3));
                        var men_awards_3 = userLogic.GetAwardFromUserAward(user_3);
                        if (men_awards_3.ToList().Count == 0)
                        {
                            Console.WriteLine($"DB has no information");
                        }
                        else
                        {
                            Console.WriteLine($"User {user_3.Name} have awards: ");
                            foreach (var item in men_awards_3)
                            {
                                Console.WriteLine($"{item.Key} : {item.Value}{Environment.NewLine}");
                            }
                        }
                        break;
                    case "4":
                        return;
                    default:
                        break;
                }
            }
        }

        //выбор действия
        private static void Actions()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"1: Action with user");
                Console.WriteLine($"2: Action with award");
                Console.WriteLine($"3: EXIT");

                Console.Write($"Choose action: ");

                var userAction = Console.ReadLine();

                switch (userAction)
                {
                    case "1":
                        UsersAction();
                        break;
                    case "2":
                        AwardsAction();
                        break;
                    case "3":
                        return;
                    default:
                        break;
                }
            }
        }

        //дейтсвия для Men
        private static void UsersAction()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"1: Find user by ID");
                Console.WriteLine($"2: Find user by Name");
                Console.WriteLine($"3: Find men by the first letter");
                Console.WriteLine($"4: Find men whose name starts or ends with the entered word");
                Console.WriteLine($"5: Delete user");
                Console.WriteLine($"6: Edit user");
                Console.WriteLine($"7: EXIT");

                Console.Write("Choose action: ");

                var userEnter = Console.ReadLine();

                switch (userEnter)
                {
                    case "1":
                        Console.Write($"Iser's ID: ");
                        var id_1 = Console.ReadLine();
                        if (Int32.TryParse(id_1, out int number_1))
                        {
                            var result_1 = userLogic.GetUserById(Int32.Parse(id_1));
                            Console.WriteLine($"{result_1.IdUser} : {result_1.Name} : {result_1.Birthday.Year}-{result_1.Birthday.Month}-{result_1.Birthday.Day} : {result_1.Age}{Environment.NewLine}");
                        }
                        else
                        {
                            Console.WriteLine($"Incorrect ID");
                        }
                        break;
                    case "2":
                        Console.Write($"User's name: ");
                        var name_2 = Console.ReadLine();
                        foreach (var item in userLogic.GetUserByName(name_2))
                        {
                            Console.WriteLine($"{item.IdUser} : {item.Name} : {item.Birthday.Year}-{item.Birthday.Month}-{item.Birthday.Day} : {item.Age}{Environment.NewLine}");
                        }
                        break;
                    case "3":
                        Console.Write($"Write letter: ");
                        var letter = Console.ReadLine();
                        var result_3 = userLogic.GetUserByLetter(Char.Parse(letter));
                        if (result_3.ToList().Count == 0)
                        {
                            Console.WriteLine($"DB has no information");
                        }
                        else
                        {
                            foreach (var item in result_3)
                            {
                                Console.WriteLine($"{item.IdUser} : {item.Name} : {item.Birthday.Year}-{item.Birthday.Month}-{item.Birthday.Day} : {item.Age}{Environment.NewLine}");
                            }
                        }
                        break;
                    case "4":
                        Console.Write($"Write word: ");
                        var word = Console.ReadLine();
                        var result_4 = userLogic.GetUserByWord(word);
                        if (result_4.ToList().Count == 0)
                        {
                            Console.WriteLine($"DB has no information");
                        }
                        else
                        {
                            foreach (var item in result_4)
                            {
                                Console.WriteLine($"{item.IdUser} : {item.Name} : {item.Birthday.Year}-{item.Birthday.Month}-{item.Birthday.Day} : {item.Age}{Environment.NewLine}");
                            }
                        }
                        break;
                    case "5":
                        Console.Write($"User's ID: ");
                        var id_5 = Console.ReadLine();
                        try
                        {
                            var user = userLogic.GetUserById(Int32.Parse(id_5));
                            userLogic.DeleteUser(user.IdUser);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"В методе {ex.TargetSite} произошла ошибка: не найден user с ID = {id_5}.");
                            UsersAction();
                        }
                        break;
                    case "6":
                        Console.Write($"User's ID: ");
                        var id_6 = Console.ReadLine();
                        if (Int32.TryParse(id_6, out int number))
                        {
                            int rightId = Int32.Parse(id_6);
                            if (userLogic.GetUserById(rightId) != null)
                            {
                                Console.Write($"User's Name: ");
                                var name_6 = Console.ReadLine();
                                Console.Write($"User's Birthday: ");
                                var birthday = Console.ReadLine();
                                userLogic.UpdateUser(rightId, name_6, birthday);
                            }
                            else
                            {
                                Console.WriteLine($"Incorrect ID");
                            }
                        }
                        break;
                    case "7":
                        return;
                    default:
                        break;
                }
            }
        }

        //дейтсвия для awards
        private static void AwardsAction()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"1: Find award");
                Console.WriteLine($"2: Find award by Name");
                Console.WriteLine($"3: Find award by the first letter");
                Console.WriteLine($"4: Find award whose name includes the entered word");
                Console.WriteLine($"5: Delete award");
                Console.WriteLine($"6: Edit award");
                Console.WriteLine($"7: EXIT");

                Console.Write("Choose action: ");

                var userEnter = Console.ReadLine();

                switch (userEnter)
                {
                    case "1":
                        Console.Write($"Award's ID: ");
                        var id_1 = Console.ReadLine();
                        var result_1 = awardLogic.GetAwardById(Int32.Parse(id_1));
                        Console.WriteLine($"{result_1.IdAward} : {result_1.Title} : {result_1.Description}{Environment.NewLine}");
                        break;
                    case "2":
                        Console.Write($"Award's Title: ");
                        var name_2 = Console.ReadLine();
                        var result_2 = awardLogic.GetAwardByTitle(name_2);
                        foreach (var item in result_2)
                        {
                            Console.WriteLine($"{item.IdAward} : {item.Title} : {item.Description}{Environment.NewLine}");
                        }
                        break;
                    case "3":
                        Console.Write($"Write letter: ");
                        var letter_3 = Console.ReadLine();
                        var result_3 = awardLogic.GetAwardByLetter(Char.Parse(letter_3));
                        if (result_3.ToList().Count == 0)
                        {
                            Console.WriteLine($"DB has no information");
                        }
                        else
                        {
                            foreach (var item in result_3)
                            {
                                Console.WriteLine($"{item.IdAward} : {item.Title} : {item.Description}{Environment.NewLine}");
                            }
                        }
                        break;
                    case "4":
                        Console.Write($"Write word: ");
                        var word = Console.ReadLine();
                        var result_4 = awardLogic.GetAwardByWord(word);
                        if (result_4.ToList().Count == 0)
                        {
                            Console.WriteLine($"DB has no information");
                        }
                        else
                        {
                            foreach (var item in result_4)
                            {
                                Console.WriteLine($"{item.IdAward} : {item.Title} : {item.Description}{Environment.NewLine}");
                            }
                        }
                        break;
                    case "5":
                        Console.Write($"Award's ID: ");
                        var id_5 = Console.ReadLine();
                        var award = awardLogic.GetAwardById(Int32.Parse(id_5));
                        if (award != null)
                        {
                            awardLogic.DeleteAward(Int32.Parse(id_5));
                        }
                        else
                        {
                            Console.WriteLine($"Incorect ID");
                        }
                        break;
                    case "6":
                        Console.Write($"award's ID: ");
                        var id_6 = Console.ReadLine();
                        var result_6 = awardLogic.GetAwardById(Int32.Parse(id_6));
                        Console.Write($"award's Titile: ");
                        var title = Console.ReadLine();
                        Console.Write($"award's Description: ");
                        var description = Console.ReadLine();
                        if(result_6 != null)
                        {
                            awardLogic.UpdateAward(Int32.Parse(id_6), title, description);
                        }
                        else
                        {
                            Console.WriteLine($"Incorrect ID");
                        }
                        
                        break;
                    case "7":
                        return;
                    default:
                        break;
                }
            }
        }
        #region OldVersion
        //private static void BasicData()
        //{

        //    var name = "Pasha";
        //    var birthday = "1996-12-04";
        //    menLogic.Adduser(name, birthday);

        //    var name1 = "Petr";
        //    var birthday1 = "1996-12-04";
        //    menLogic.Adduser(name1, birthday1);

        //    var name4 = "Pasha";
        //    var birthday4 = "1294-04-04";
        //    menLogic.Adduser(name4, birthday4);

        //    var name2 = "Misha";
        //    var birthday2 = "1996-12-04";
        //    menLogic.Adduser(name2, birthday2);

        //    var name3 = "Pasha";
        //    var birthday3 = "1990-04-12";
        //    menLogic.Adduser(name3, birthday3);


        //    var title = "Good boy";
        //    var description = "For nothing";
        //    awardsLogic.Addaward(title, description);

        //    var title1 = "Bad boy";
        //    var description1 = "For nothing";
        //    awardsLogic.Addaward(title1, description1);

        //    var title2 = "Neutral boy";
        //    var description2 = "For nothing";
        //    awardsLogic.Addaward(title2, description2);


        //    var iD_user = "1";
        //    var iD_award = "1";
        //    menAndawardsLogic.AddMen_awards(iD_user, iD_award);

        //    var iD_user1 = "1";
        //    var iD_award1 = "2";
        //    menAndawardsLogic.AddMen_awards(iD_user1, iD_award1);

        //    var iD_user2 = "1";
        //    var iD_award2 = "3";
        //    menAndawardsLogic.AddMen_awards(iD_user2, iD_award2);

        //    var iD_user3 = "2";
        //    var iD_award3 = "1";
        //    menAndawardsLogic.AddMen_awards(iD_user3, iD_award3);

        //    var iD_user4 = "2";
        //    var iD_award4 = "2";
        //    menAndawardsLogic.AddMen_awards(iD_user4, iD_award4);

        //    var iD_user5 = "3";
        //    var iD_award5 = "1";
        //    menAndawardsLogic.AddMen_awards(iD_user5, iD_award5);
        //}
        #endregion


    }
}
