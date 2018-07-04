using ConsoleApp1.Entities;
using System;
using System.Collections.Generic;


namespace ConsoleApp1.DAL.Interface
{
    public interface INoteDAO
    {
        bool Add(Note note);
        IEnumerable<Note> GetAll();
        Note GetByID(Guid id);
    }
}