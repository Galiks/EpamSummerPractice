﻿using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAward.BLL.Interface;
using UserAward.BLL.Logic;
using UserAward.Container;

namespace userAward
{
    class Program
    {
        private static IUserLogic userLogic;
        private static IAwardLogic awardLogic;

        static void Main(string[] args)
        {
            NinjectCommon.Registration();

            userLogic = NinjectCommon.Kernel.Get<IUserLogic>();
            awardLogic = NinjectCommon.Kernel.Get<IAwardLogic>();

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
                Console.WriteLine($"3: HELP");
                Console.WriteLine($"4: EXIT");

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
                        Console.WriteLine($"HELP YOURSELF");
                        break;
                    case "4":
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

        //дейтсвия для Users
        private static void UsersAction()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"1: Find user by ID");
                Console.WriteLine($"2: Find user by Name");
                Console.WriteLine($"3: Find men by the first letter");
                Console.WriteLine($"4: Find men whose name starts or ends with the entered word");
                Console.WriteLine($"5: Rewarding");
                Console.WriteLine($"6: Delete user");
                Console.WriteLine($"7: Edit user");
                Console.WriteLine($"8: EXIT");

                Console.Write("Choose action: ");

                var userEnter = Console.ReadLine();

                switch (userEnter)
                {
                    case "1":
                        Console.Write($"User's ID: ");
                        var id_1 = Console.ReadLine();
                        var userById = userLogic.GetUserById(id_1);
                        if (userById != null)
                        {
                            Console.WriteLine($"{userById.IdUser} : {userById.Name} : {userById.Birthday.Year}-{userById.Birthday.Month}-{userById.Birthday.Day} : {userById.Age}{Environment.NewLine}");
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
                        Console.Write($"User ID: ");
                        var userId = Console.ReadLine();
                        Console.Write($"Award ID: ");
                        var awardId = Console.ReadLine();
                        Rewarding(userId, awardId);
                        break;
                    case "6":
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
                    case "7":
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
                    case "8":
                        return;
                    default:
                        break;
                }
            }
        }

        private static void Rewarding(string userId, string awardId)
        {
            int awardIdForParse;
            if (Int32.TryParse(awardId, out awardIdForParse))
            {
                if (awardLogic.GetAwardById(awardIdForParse) != null)
                {
                    userLogic.Rewarding(userId, awardIdForParse);
                }
                else
                {
                    Console.WriteLine($"Incorrect Award's ID");
                }
            }
            else
            {
                Console.WriteLine($"Incorrect Award's ID");
            }
        }

        //дейтсвия для Awards
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
                        if (result_6 != null)
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
    }
}