using System;

namespace ConsoleApp1.Entities
{
    public class Note
    {
        public Guid ID { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }

        public Note(Guid id, string text, DateTime createDate)
        {
            this.ID = id;
            this.Text = text;
            this.CreateDate = createDate;
        }

        public Note()
        {

        }
    }
}
