namespace Forum.App
{
    using System;
    using System.IO;

    using Forum.Data;
    using Forum.Models;
    using Forum.Services;
    using Forum.App.ModelsDto;
    using Forum.Services.Contracts;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var serviceProvider = ConfigureService();

            //InitializeAutomapper();

            var engine = new Engine(serviceProvider);
            engine.Run();

        }

        //Това не ни трябва,ако имаме Automapper.Extensions.Microsoft.DependencyInjection
        private static void InitializeAutomapper()
        {
            //Може да се инициализира само с Mapper.Initialize(), но все пак е препоръчително да се пише конфигурация.
            Mapper.Initialize(configure =>
            {
                //Ползваме нещата от ForumProfile.cs
                configure.AddProfile<ForumProfile>();
                //configure.CreateMap<Post, PostDetailsDto>()
                //        .ForMember(dto => dto.ReplyCount,
                //                    cfg => cfg.MapFrom(post => post.Replies.Count));

                //configure.CreateMap<Post, ReplyDto>();

                //configure.CreateMap<Post, PostDto>()
                //        .ForMember(dto => dto.AuthorUsername,
                //                    cfg => cfg.MapFrom(post => post.Author.Username));
            });
        }

        private static IServiceProvider ConfigureService()
        {
            //Инсталираме install-package Microsoft.Extensions.DependencyInjection
            //за да можем да ползваме dependency injection

            var serviceCollection = new ServiceCollection();

            //install-package Microsoft.Extensions.Configuration.Json
            //install-package Microsoft.Extensions.Configuration.Xml
            var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appConfig.json")
                    //.AddXmlFile("appConfig.xml")
                    .Build();

            serviceCollection.AddDbContext<ForumDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("Dev"))
            );

            serviceCollection.AddTransient<IDatabaseInitializerService, DatabaseInitializerService>();
            serviceCollection.AddTransient<IUserService, UserService>();
            serviceCollection.AddTransient<IPostService, PostService>();
            serviceCollection.AddTransient<ICategoryService, CategoryService>();
            serviceCollection.AddTransient<IReplyService, ReplyService>();

            //install-package Automapper.Extensions.Microsoft.DependencyInjection
            serviceCollection.AddAutoMapper(cfg => cfg.AddProfile<ForumProfile>());

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider;
        }
    }
}
