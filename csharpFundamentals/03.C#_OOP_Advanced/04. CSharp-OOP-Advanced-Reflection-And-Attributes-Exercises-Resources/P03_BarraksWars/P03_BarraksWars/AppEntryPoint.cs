namespace _03BarracksFactory
{
    using Contracts;
    using Core;
    using Core.Factories;
    using Data;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public class AppEntryPoint
    {
        public static void Main()
        {
            IServiceProvider serviceProvider = ConfigureServices();

            //Махаме repository и unitFactory, защото serviceProvider ги държи тях вече.

            //IRepository repository = new UnitRepository();
            //IUnitFactory unitFactory = new UnitFactory();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);
            IRunnable engine = new Engine(commandInterpreter);
            engine.Run();
        }

        private static IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddTransient<IUnitFactory, UnitFactory>(); //Това е нещо което го дава когато се поиска и след това го трие

            services.AddSingleton<IRepository, UnitRepository>(); //Това е нещо което стои по време на целия Execute на програмата.

            IServiceProvider serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
