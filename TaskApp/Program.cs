using System;

using TaskApp.Classes;
using TaskApp.Interfaces;

namespace TaskApp
{
    class Program
    {
        
        static void Main(string[] args)
       {
            
            var app = new SuperTaskApp();
            app.Start();
            
        }

    }
}

