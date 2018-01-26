namespace BookShop.StartUp
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    using BookShop.Data;
    using BookShop.Models;
    using BookShop.Initializer;

    public class StartUp
    {
        static void Main(string[] args)
        {
            //using (var context = new BookShopContext())
            //{
            //    DbInitializer.ResetDatabase(context);
            //}
            var context = new BookShopContext();

            var command = Console.ReadLine().ToLower();

           GetBooksByAgeRestriction(context,command);
            
        }

        private static void GetBooksByAgeRestriction(BookShopContext context,string command)
        {
            AgeRestriction ageRestriction;
            switch (command)
            {
                case "teen":ageRestriction = AgeRestriction.Teen;break;
                case "minor":ageRestriction = AgeRestriction.Minor;break;
                case "adult":ageRestriction = AgeRestriction.Adult;break;
                default:
                    return;
            }

            var titles = context.Books
                    .Where(b => b.AgeRestriction == ageRestriction)
                    .Select(b => b.Title)
                    .OrderBy(x => x)
                    .ToList();

            if (titles.Any())
            {
                Console.WriteLine(string.Join(Environment.NewLine,titles));
            }
        }
    }
}
