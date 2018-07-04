using ConsoleApp1.BUS.Interface;
using ConsoleApp1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.BUS.Core
{
    public class Logic : ILogic
    {
        public bool Add(Note note)
        {
            note.ID = Guid.NewGuid();
            note.CreateDate = DateTime.Now;

            return DAOs.NoteDAO.Add(note);
        }

        public IEnumerable<Note> GetAll() //нельзя прокидывать IEnumerable сквозь слой
        {
            return DAOs.NoteDAO.GetAll().ToList();
        }

        
    }
}
