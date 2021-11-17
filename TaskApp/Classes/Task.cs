using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Classes
{
    class Task : Item
    {
      
        public Task(string title) : base(title)
        {
            type = "task";
        }
    }
}
