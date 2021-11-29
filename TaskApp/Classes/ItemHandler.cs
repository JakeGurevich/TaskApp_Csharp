using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TaskApp.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace TaskApp.Classes
{
    class ItemHandler : IEditable
    {
       public List<Item> itemList;
        private static ILogger<Program> _logger;
        private static ServiceProvider _serviceProvider;





        public ItemHandler()
        {
           
            InitilazeLogger();
            GetFromJson();
        }


        public Item CreateItem()
        {
            Console.WriteLine("Enter your task to do :");
            var taskName = Console.ReadLine();
            Console.WriteLine("Enter type of goal ,  if it's a bylist  - enter 'b',  if it's a goal  - enter 'g', if it's a task to do  - press enter, ");
            var taskType = Console.ReadLine();
            Item newItem ;
            switch (taskType) 
            {
                case "b":

                newItem = new Buylist(taskName);
                    break;
                case "g":

                    newItem = new Goal(taskName);
                    break;


                default:
                    newItem = new Task(taskName);
                    break;
            }
            return newItem;
        }
           
            
        

      
        public void AddItem(Item newItem)
        {

            itemList.Add(newItem);
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
        public void filterItems(string word)
        {
            var index = 1;
            Console.WriteLine("*******************");
            Console.WriteLine("Your filtered tasks:");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~");
            var filteredList = from item in itemList
                               where item.Title.Contains(word)
                               select item;
          
            foreach (var item in filteredList)
            {

                Console.WriteLine($"{index}. {item.ToString()}");
                Console.WriteLine("------------------");
                index++;
            }
        }
        public void optionHandler(SuperTaskApp app)
        {
            Console.WriteLine("Want to add more tasks? Press m");
            Console.WriteLine("Want to delete the task? Press d");
            Console.WriteLine("Want to edit the task? Press e");
            Console.WriteLine("Want to find  task by name? Press f");
            Console.WriteLine("Want to exit? Press s");
            var input = Console.ReadLine();
           
            switch (input)
            {
                case "s":
                    Console.WriteLine("Are you sure that you want to exit? If 'Yes' press y ,if 'No' press Enter");
                    var answer = Console.ReadLine();
                    if (answer == "y")
                    {
                        SaveToJson(itemList);
                        app.Stop();
                    } 
                  
                        break;
                case "f":
                    Console.WriteLine("Enter name of the task you want to find?");
                    var word = Console.ReadLine();
                    filterItems(word);
                    Console.WriteLine("If you want to see all tasks , press b");
                    var back = Console.ReadLine();
                    if (back.ToLower() == "b")
                    {
                        ShowItems();
                        optionHandler(app);
                    }
                    else
                    {
                        optionHandler(app);
                    }
                   
                    break;

                case "d":
                    Console.WriteLine("Enter number of the task :");
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
                    Console.WriteLine("Please enter one of the following options :");
                    optionHandler(app);
                    break;
                    
            }

        }

        public static void InitilazeLogger()
        {

            _serviceProvider = new ServiceCollection()
                            .AddLogging(configuration =>
                            {
                                configuration.AddConsole();
                                configuration.SetMinimumLevel(LogLevel.Debug);
                            })
                            .AddSingleton<IEditable, ItemHandler>()
                            .BuildServiceProvider();

            _logger = _serviceProvider.GetService<ILoggerFactory>()
                    .CreateLogger<Program>();
        }
        public static void SaveToJson(List<Item> list)
        {
            var path = @"C:\Users\pc\Tests\text.json";
            try
            {
               var Json = JsonConvert.SerializeObject(list);
                
                // This text is added only once to the file.
                // Create a file to write to.

                    File.WriteAllText(path, Json, Encoding.UTF8);     
            }

            catch (Exception e)
            {
                _logger.LogError("SaveToJson: " + e.Message);
            }
        }
        private  void GetFromJson()
        {
           
            try
            {
                var filename = @"C:\Users\pc\Tests\text.json";

                var text = File.ReadAllText(filename);

                itemList = JsonConvert.DeserializeObject<List<Item>>(text);
                _logger.LogInformation(" GetFromJson Success!");
            }

            catch (Exception e)
            {
               _logger.LogError("GetFromJson : " + e.Message);
            }
        }
    }
}
