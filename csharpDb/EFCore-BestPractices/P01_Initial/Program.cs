using AutoMapper;
using AutoMapper.QueryableExtensions;
using Forum.App.ModelsDto;
using Forum.Data;
using Forum.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace P01_Initial
{
    class Program
    {
        static void Main(string[] args)
        {
            //One();
            //Two();
            //Three();
            //Four();
            //Five();
        }

        private static void Five()
        {
            //Design Patters (виж dependency injection)

            //Singleton Pattern -- един глобален state, една инстанция (да си създадем такъв клас,който има една единствена инстанция от него) (правим private constructor) (в getter-a може да кажем,ако не  е инстанциран да го инстанцираме).
            //Отличителен белег за Singleton Pattern e private конструктор(правим private конструктор,за да не можем да инстанцираме други такива обекти от този клас).
            
            //Service Locator Pattern -- Глобален Service клас.

            //Command Pattern -- Позволява да имаме //класове//команди
        }

        private static void Four()
        {
            using (var context = new ForumDbContext())
            {
                //Ше вземе user-ите като разкачени от базата.
                var users = context.Users
                    .AsNoTracking() // <<--- Използваме AsNoTracking() когато искаме да вземем entity-та разкачени от базата. //Важното е ,че няма да се проследява дали са променени //Това забранява и Cache-a на EFCore.
                    .Where(u => u.Id % 2 == 0)
                    .ToList();

            }
        }

        private static void Three()
        {
            using (var context = new ForumDbContext())
            {
                //Предотвратяваме промени в базата с ChangeTracker-a.
                //Могат само да се четат.
                context.ChangeTracker.AutoDetectChangesEnabled = false;

                var user = context.Users.Find(1);
                user.Password = "12j3o5";

                context.SaveChanges();
                //AutoDetectChangesEnabled = false => няма да се запаметят промените в базата.

            }
        }

        private static void Two()
        {
            //Кодът може да се разделя на следните секции:
            //  Data Layer -- тук се държи context-a (тук се държат и миграциите)
            //  Domain Models -- класовете
            //  Client -- логиката на аппликацията
            //  Business Logic Layer (optional,но все пак много препоръчителен (Service-и тук е бизнес логиката на нашето приложение.Можем да имаме няколко Service-а, които работят с различни Entity-та от базата)) (Това понякога се нарича Fascade pattern (или нещо от сорта))
        }

        private static void One()
        {
            //Кодът трябва да е скаларен (scalable) (Да работи еднакво както при малко така и при много User-и).

            //Да може да се поддържа по-лесно кода (maintainability).

            //Manageability да е ясно дефиниран ,също да можем лесно да променяме кодът без да променяме нещо фундаментално в него. 

            //Да може да се тества. (Главно работим с Interface-и)
        }
    }
}
