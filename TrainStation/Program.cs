using System;
using Autofac;

namespace TrainStation
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();
            var app = scope.Resolve<IApplication>();
            
            do
            {
                while (!Console.KeyAvailable)
                {
                    var letter = Console.ReadLine();
                    app.Run(letter);
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);




        }
    }
}
