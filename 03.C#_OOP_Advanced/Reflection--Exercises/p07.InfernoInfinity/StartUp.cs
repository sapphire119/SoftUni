namespace p07.InfernoInfinity
{
    using System;
    using Microsoft.Extensions.DependencyInjection;

    public class StartUp
    {
        public static void Main()
        {
            IReadable readable = new Reader();
            IServiceProvider serviceProvider = GetServices();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(serviceProvider);

            Engine engine = new Engine(readable, commandInterpreter);
            engine.Run();
        }

        private static IServiceProvider GetServices()
        {
            var services = new ServiceCollection();

            services.AddTransient<IItemFactory, ItemFactory>();

            services.AddTransient<IWriteable, Writer>();

            services.AddSingleton<IRepository, WeaponRepository>();

            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
