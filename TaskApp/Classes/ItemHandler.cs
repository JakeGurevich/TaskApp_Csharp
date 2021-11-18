using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TaskApp.Interfaces;

namespace TaskApp.Classes
{
    class ItemHandler : IEditable
    {
       private List<Item> itemList;






        public ItemHandler()
        {
            
            var filename = @"C:\Users\pc\Tests\text.json";

            var text = File.ReadAllText(filename);

             itemList = JsonConvert.DeserializeObject<List<Item>>(text);
        }


        public string CreateItem()
        {
            Console.WriteLine("Enter your task to do :");
            var input = Console.ReadLine();
            return input;
            
        }

        public string CreateType()
        {
            Console.WriteLine("Enter type of goal ,  if it's a bylist  - enter 'b',if it's a task to do  - press enter, ");
            var input = Console.ReadLine();
            return input;

        }
        public void AddItem(string title,string type)
        {
          if (type == "b")
            {
                itemList.Add(new Buylist(title));
            } else
            {
                itemList.Add(new Task(title));
            }
        }

        public void EditItem(int position,string title, SuperTaskApp app)
        {
            itemList[position-1].Title = title;
            ShowItems();
            optionHandler(app);
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
            Console.WriteLine("Want to edit the task? Press e");
            Console.WriteLine("Want to exit? Press s");
            var input = Console.ReadLine();
           
            switch (input)
            {
                case "s":
                    Console.WriteLine("Are you sure that you want to exit? If 'Yes' press y ,if 'No' press Enter");
                    var answer = Console.ReadLine();
                    if (answer == "y")
                    {
                        SaveToTxt(itemList);
                        app.Stop();
                    } 
                  
                        break;
                            
                case "d":
                    Console.WriteLine("Enteer number of the task :");
                    var taskToDelete = Convert.ToInt32(Console.ReadLine());
                    RemoveItem(taskToDelete,app);
                    break;
                case "e":
                    Console.WriteLine("Enter number of the task to edit :");
                    var taskToEdit = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter new Title :");
                    var newTitle = Console.ReadLine();
                    EditItem(taskToEdit,newTitle, app);
                    break;



                default:
                    
                    break;
                    
            }

        }
        public static void SaveToTxt(List<Item> list)
        {
            var path = @"C:\Users\pc\Tests\text.json";
            try
            {
               var Json = JsonConvert.SerializeObject(list);
                // This text is added only once to the file.
                // Create a file to write to.

                    File.WriteAllText(path, Json, Encoding.UTF8);
                
               
                // using (TextWriter tw = new StreamWriter(writePath))
                // {
                //  var index = 1;
                //  foreach (var item in list)
                //  {
                //     tw.WriteLine($"{index}. { item.ToString()}");
                //     index++;
                //  }
                // }
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }   
    }
}
