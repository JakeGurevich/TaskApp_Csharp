using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Classes
{
    class SuperTaskApp
    {
        private bool go = true;



       public void Start()
        {
            Console.WriteLine("   Welcome to best Task app!");
            Console.WriteLine(" ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
            var TaskApp = new ItemHandler();
            while (go)
            {
                var taskName = TaskApp.CreateItem();
                var type = TaskApp.CreateType();
                TaskApp.AddItem(taskName, type);
                TaskApp.ShowItems();
                
                TaskApp.optionHandler(this);
            }
        }
        public void Stop()
        {
            go = false;
        }
    }
}
