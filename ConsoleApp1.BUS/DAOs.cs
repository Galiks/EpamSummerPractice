using ConsoleApp1.DAL.Core;
using ConsoleApp1.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.BUS.Core
{
    class DAOs
    {
        static DAOs()
        {
            NoteDAO = new NoteDAO();
        }

        public static INoteDAO NoteDAO { get; }
    }
}
