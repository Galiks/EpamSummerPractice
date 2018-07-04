using System.Collections.Generic;
using ConsoleApp1.Entities;

namespace ConsoleApp1.BUS.Interface
{
    public interface ILogic
    {
        bool Add(Note note);
        IEnumerable<Note> GetAll();
    }
}