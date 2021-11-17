using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Interfaces
{
    interface Ieditable
    {
        public void AddItem(string title,string type);
        public void RemoveItem();
        public void EditItem();
       

    }
}
