using ConsoleApp1.BUS.Core;
using ConsoleApp1.BUS.Interface;
using ConsoleApp1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogic logic = new Logic();
            MethodForUI(logic);
        }

        private static void MethodForUI(ILogic logic)
        {
            while (true)
            {
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Show all");
                Console.WriteLine("0. Exit");

                Console.WriteLine("Choose action: ");

                var userEnter = Console.ReadLine();

                switch (userEnter)
                {
                    case "1":
                        Console.WriteLine("Enter text");
                        var input = Console.ReadLine();
                        var newNote = new Note { Text = input};
                        logic.Add(newNote);
                        break;
                    case "2":
                        var notes = logic.GetAll();
                        foreach (var item in notes)
                        {
                            Console.WriteLine($"{item.ID} : {item.Text} : {item.CreateDate}");
                        }
                        break;
                    case "0":
                        //exit
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
