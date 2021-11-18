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

        public void RemoveItem(int position,SuperTaskApp app)
        {
            itemList.RemoveAt(position-1);
            ShowItems();
            optionHandler(app);
        }
        public void ShowItems()
        {
            var index = 1;
            Console.WriteLine("*******************");
            Console.WriteLine("Your tasks:");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~");
            foreach (var item in itemList)
            {
              
               Console.WriteLine ($"{index}. {item.ToString()}");
                Console.WriteLine("------------------");
                index++;
            }
        }
        public void optionHandler(SuperTaskApp app)
        {
            Console.WriteLine("Want to add more tasks? Press m");
            Console.WriteLine("Want to delete the task? Press d");
            Console.WriteLine("Want to exit? Press s");
            var input = Console.ReadLine();
           
            switch (input)
            {
                case "s":
                    app.Stop();
                    break;
                case "d":
                    Console.WriteLine("Enteer number of the task :");
                    var taskToDelete = Convert.ToInt32(Console.ReadLine());
                    RemoveItem(taskToDelete,app);
                    break;


                default:
                    
                    break;
                    
            }

        }
    }
}
