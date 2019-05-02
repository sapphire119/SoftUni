namespace Employees.App
{
    using AutoMapper;
    using Employees.Data;
    using Employees.Models;
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            ResetDatabase(); //Вътре има и Seed() метод.

            Mapper.Initialize(config => config.AddProfile<EmployeesProfile>());

            var commandParser = new CommandParser();

            var engine = new Engine(commandParser);

            engine.Run();
        }

        private static void ResetDatabase()
        {
            using (var context = new EmployeeDbContext())
            {
                context.Database.EnsureDeleted();

                context.Database.EnsureCreated();

                Seed(context);
            }
        }

        private static void Seed(EmployeeDbContext context)
        {
            var employees = new[]
            {
                new Employee { Address = "Sofia, bul. Hristo Botev 12", Birthday = new DateTime(1992,12,12), FirstName = "Petur", LastName = "Ivanov", Salary = 1300, ManagerId = 2},
                new Employee { Address = "Burgas, str. Main Street In Burgas 12", Birthday = new DateTime(1975,10,14), FirstName = "Maria", LastName = "Petrova", Salary = 5555},
                new Employee { Address = "Sofia, bul. Djeims Baucher 43", Birthday = new DateTime(1984,5,6), FirstName = "Georgi", LastName = "Marinov", Salary = 4345, ManagerId = 2},
                new Employee { Address = "New York City, Madison avenue", Birthday = new DateTime(1977,6,9), FirstName = "Petkan", LastName = "Petkanov", Salary = 2357, ManagerId = 2},
                new Employee { Address = "London, Trafalgar Square", Birthday = new DateTime(1966,3,3), FirstName = "Genadi", LastName = "Vasilev", Salary = 83734},
                new Employee { Address = "Pleven, ul. Vasil Levksi", Birthday = new DateTime(1944,5,4), FirstName = "Lazar", LastName = "Ivanov", Salary = 67346},
                new Employee { Address = "Muninch, bul. Gallunsanlage", Birthday = new DateTime(1989,9,7), FirstName = "Teo", LastName = "Stoicov", Salary = 5437, ManagerId = 4},
                new Employee { Address = "Bordou, Wine street or sth", Birthday = new DateTime(1992,5,8), FirstName = "David", LastName = "Makronov", Salary = 322, ManagerId = 13},
                new Employee { Address = "Ancinet Babylon, Unknown", Birthday = new DateTime(0001,01,01), FirstName = "Goliat", LastName = "Nemiren", Salary = 6634, ManagerId = 4},
                new Employee { Address = "Ancient Babylon, Main street", Birthday = new DateTime(01,01,02), FirstName = "Angel", LastName = "Dobromirov", Salary = 7347},
                new Employee { Address = "Boston, Main street", Birthday = new DateTime(1982,5,12), FirstName = "Bill", LastName = "Christian", Salary = 734, ManagerId = 13},
                new Employee { Address = "bul. Hristo Botev 12", Birthday = new DateTime(251,1,6), FirstName = "Random", LastName = "Person", Salary = 2347, ManagerId = 13},
                new Employee { Address = "Random, random", Birthday = new DateTime(1762,4,9), FirstName = "Cool", LastName = "Dude", Salary = 9999},
                new Employee { Address = "St.PetersBurg, bul. Dasvidanq", Birthday = new DateTime(742,1,30), FirstName = "Summer", LastName = "Stevenson", Salary = 5689},
                new Employee { Address = "Beijing, Xi huei chon yu", Birthday = new DateTime(1864,9,9), FirstName = "Lee", LastName = "Xing", Salary = 68568},
                new Employee { Address = "Dallas, Peace street 14", Birthday = new DateTime(1763,8,8), FirstName = "Rakisha", LastName = "Noelle", Salary = 45845}
            };

            context.Employees.AddRange(employees);

            context.SaveChanges();
        }
    }
}
