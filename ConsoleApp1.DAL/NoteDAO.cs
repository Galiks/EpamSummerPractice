using ConsoleApp1.DAL.Interface;
using ConsoleApp1.Entities;
using System;
using System.Collections.Generic;

namespace ConsoleApp1.DAL.Core
{
    public class NoteDAO : INoteDAO
    {
        private static IDictionary<Guid,Note> notes;

        static NoteDAO()
        {
            notes = new Dictionary<Guid,Note>();
        }

        public bool Add(Note note)
        {
            if (notes.ContainsKey(note.ID))
            {
                return false;
            }

            notes.Add(note.ID, note);

            return true;
        }

        public IEnumerable<Note> GetAll()
        {
            return notes.Values;
        }

        public Note GetByID(Guid id)
        {
            if (notes.ContainsKey(id))
            {
                return notes[id];
            }

            return null;
        }
    }
}
