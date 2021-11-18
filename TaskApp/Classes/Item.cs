using System;

namespace TaskApp.Classes
{
    internal class Item
    {
        private static int count = 1;
        private int _id;
        protected string type;
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public Item(string title)
        {
            Title = title;
            CreatedAt = DateTime.Now;
            _id = count;
            count++;
        }
        public override string ToString()
        {
            return  $" Title : {Title} ({type}) , Created at:{CreatedAt.ToString("MM/dd/yy HH:mm")}";
        }
    }
}