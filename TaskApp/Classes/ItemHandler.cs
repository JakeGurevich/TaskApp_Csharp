using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskApp.Interfaces;

namespace TaskApp.Classes
{
    class ItemHandler : Ieditable
    {
       private List<Item> itemList;






        public ItemHandler()
        {
            itemList = new List<Item>();
        }


        public string CreateItem()
        {
            Console.WriteLine("Enter your task to do :");
            var input = Console.ReadLine();
            return input;
            
        }

        public string CreateType()
        {
            Console.WriteLine("Enter type of goal , if it's a task to do  - enter 'task', if it's bylist  - enter 'buylist' ");
            var input = Console.ReadLine();
            return input;

        }
        public void AddItem(string title,string type)
        {
            if (type == "task")
            {
                itemList.Add(new Task(title));
            }
            else if (type == "buylist")
            {
                itemList.Add(new Buylist(title));
            } else
            {
                itemList.Add(new Task(title));
            }
        }

        public void EditItem()
        {
           
        }

        public void RemoveItem()
        {
           
        }
        public void ShowItems()
        {
            Console.WriteLine("*******************");
            Console.WriteLine("Your tasks:");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~");
            foreach (var item in itemList)
            {
               Console.WriteLine (item.ToString());
                Console.WriteLine("------------------");
            }
        }
        public void optionHandler(SuperTaskApp app)
        {
            Console.WriteLine("Want to add more tasks? Press m");
            Console.WriteLine("Want to exit? Press s");
            var input = Console.ReadLine();
           
            switch (input)
            {
                case "s":
                    app.Stop();
                    break;
                

                default:
                    
                    break;
                    
            }

        }
    }
}
