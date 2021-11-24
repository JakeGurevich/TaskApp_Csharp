using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TaskApp.Interfaces;

namespace TaskApp.Classes
{
    class SuperTaskApp
    {
        private static ILogger<Program> _logger;
        private static ServiceProvider _serviceProvider;
        private bool go = true;
        private static AppState _currentState = AppState.Initialazing;



       public void Start()
        {
            InitilazeLogger();
            LogState();
            _currentState = AppState.Started;
            LogState();
            WelcomeMessage();
            
            var TaskApp = new ItemHandler();
            
            while (go)
            {
                var newItem = TaskApp.CreateItem();
               
                
                TaskApp.AddItem(newItem);
                
                TaskApp.ShowItems();
                
                TaskApp.optionHandler(this);
            }
        }
        public void Stop()
        {
            _currentState = AppState.Ended;
            LogState();
            go = false;
        }
        public void WelcomeMessage()
        {
            Console.WriteLine("   Welcome to best Task app!");
            Console.WriteLine(" ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^");
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

        private static void LogState() 
        {
            _logger.LogDebug($"App state: { _currentState}");
        }
        enum AppState
        {
            Initialazing,
            Started,
            Ended
        }
    }
}
