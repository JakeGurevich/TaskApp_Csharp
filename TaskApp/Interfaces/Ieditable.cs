using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Classes;

namespace TaskApp.Interfaces
{
    interface Ieditable
    {
        public void AddItem(string title,string type);
        public void RemoveItem(int position,SuperTaskApp app);
        public void EditItem();
       

    }
}
