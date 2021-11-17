using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Classes
{
    class Buylist : Item
    {
        public Buylist(string title) : base(title)
        {
            type = "buylist";
        }
    }
}
