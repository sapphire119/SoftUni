namespace p01_Initial
{
    using System;
    using System.Linq;

    using p01_Initial.Data;
    using p01_Initial.Data.Models;

    using Microsoft.EntityFrameworkCore;

    using Z.EntityFramework.Plus;

    class StartUp
    {
        static void Main(string[] args)
        {
            //First();
            //Second();
            //SecondPrim();
            //Third();
            //Fourth();
            //Fifth();
            //Sixth();
            //Seventh(); // Bulk операции (да променяме по много неща наведнъж)
            //Използваме Z.EntityFrameworkCore

            //Eight(); //Видове loading-и
            //Nine(); //Concurrency check-ове (First One Wins) //Последователност на запазване на данни в базата
            //Ten(); //Concurrency check-ове (Last One Wins) //Последователност на запазване на данни в базата
            Eleven(); //Каскадни операции са пуснати по default в EFCore

        }

        private static void Eleven()
        {

        }

        private static void Ten()
        {
            //Concurrency Check
            //Last one wins е default-ната Concurrency Check конфигурацията.

            //Пример за Last One Wins 

            var context = new EmployeesDbContext();
            var context2 = new EmployeesDbContext();

            var firstEmployee = context.Employees.Find(2);
            var secondEmployee = context2.Employees.Find(2);

            Console.WriteLine(firstEmployee.FirstName);
            Console.WriteLine(secondEmployee.FirstName);

            firstEmployee.Salary = 3500;
            secondEmployee.Salary = 1500;

            context2.SaveChanges();
            context.SaveChanges();
        }

        private static void Nine()
        {
            //Concurrency Check
            //Last one wins е default-ната Concurrency Check конфигурацията.

            //Пример за First One Wins 
            //(За да имаме First One Wins променяме DbContext-a променяме EmployeeDbContext и към дадено property в модел builder-a добавяме --- >>
            //builder.Entity<Employee>(entity => 
            //{
            //  entity.Property(e => e.Salary)
            //      .IsConcurrencyToken(); 
            //});

            var context = new EmployeesDbContext();
            var context2 = new EmployeesDbContext();

            var firstEmployee = context.Employees.Find(2);
            var secondEmployee = context2.Employees.Find(2);

            Console.WriteLine(firstEmployee.FirstName);
            Console.WriteLine(secondEmployee.FirstName);

            firstEmployee.Salary = 3500;
            secondEmployee.Salary = 1500;

            context2.SaveChanges();
            context.SaveChanges();
        }

        private static void Eight()
        {
            //Explicit loading <-- Включва цялата инфорамация за даден обект
            //Eager loading
            //Lazy loading <-- Мързеливо зареждане, зарежда нещата в момента ,в който ги ползваме.
                //В момента е EFCore няма Lazy Loading, но има шанс да го имплементират в 2.1.0
        }

        private static void Seventh()
        {
            var context = new EmployeesDbContext();

            //var employees = new[]
            //{
            //    //new Employee { FirstName= "Pesho", LastName = "Karburatora", Salary = 4500},
            //    //new Employee { FirstName = "Ivan", LastName = "Цокъла", Salary= 5000},
            //    new Employee { FirstName = "Ivan", LastName = "Джавара", Salary = 1500},
            //    new Employee { FirstName = "Ivan", LastName = "Пустиняка", Salary = 2000},
            //    new Employee { FirstName = "Ivan", LastName = "Кокъла", Salary = 1750},
            //};

            //context.Employees.AddRange(employees);
            //context.SaveChanges();
            var employees = context.Employees
                    .Where(e => e.Salary < 3000)
                    .Update(e => new Employee { Salary = e.Salary + 1750 });

            //foreach (var employee in employees)
            //{
            //    employee.Salary = 5;
            //}
            context.SaveChanges();
            //context.Employees.Where(e => e.Salary < 3000)
            //    .Delete(); // Z.Plus.EFCore
        }

        private static void Sixth()
        {
            var context = new EmployeesDbContext();

            var querry = @"EXEC usp_UpdateSalary {0}, {1}";

            var result = context.Database.ExecuteSqlCommand(querry, 2, 200);

            Console.WriteLine(result);
        }

        private static void Fifth()
        {
            var context = new EmployeesDbContext();

            var employees = context.Employees
                    .AsNoTracking()
                    .ToArray();

            var firstEmployee = context.Entry(employees.First()).State;

            //Ако извикаме context.SaveChanges() нищо няма да стане/да се промени

            //Всички employee-та стават AsNoTracking ще бъдат разкачени от самия db-context (базата) и няма да участват в него
        }

        private static void Fourth()
        {
            Employee employee;
            using (var context = new EmployeesDbContext())
            {
                employee = context.Employees.Find(1);

                //Променя му state-a просто заминава от базата
                context.Entry(employee).State = EntityState.Deleted;

                context.SaveChanges();

                //изтрива Employee-то (базата го смята за изтрито)
            }
        }

        private static void Third()
        {
            Employee employee;
            using (var context = new EmployeesDbContext())
            {
                employee = context.Employees.Find(1);

                context.Entry(employee).State = EntityState.Detached;

                var employeeState = context.Entry(employee).State;

                employee.FirstName = "Miro";

                context.SaveChanges();

                //Не променя името на Employee-то
            }
        }

        private static void SecondPrim()
        {
            Employee employee;
            using (var context = new EmployeesDbContext())
            {
                employee = context.Employees.Find(1);

                var employee2 = context.Employees.Find(2);

                var state1 = context.Entry(employee).State;
                var state2 = context.Entry(employee2).State = EntityState.Detached; //Откача employee2 от базата и не може да се променя нищо по него
            }
        }

        private static void Second()
        {
            Employee employee;
            using (var context = new EmployeesDbContext())
            {
                //var employees = new[]
                //{
                //    new Employee {FirstName="Pesho",LastName="Goshev",Salary=3500},
                //    new Employee {FirstName="Ivan",LastName="Ivanov",Salary=3500},
                //    new Employee {FirstName="Kiril",LastName="Xamarinov",Salary=3500},
                //};

                //context.Employees.AddRange(employees);
                //context.SaveChanges();

                employee = context.Employees.Find(1);

                var employee2 = context.Employees.Find(2);

                var state1 = context.Entry(employee).State;
                var state2 = context.Entry(employee2).State = EntityState.Detached; //Откача employee2 от базата и не може да се променя нищо по него
                    


                //Required columns must always be selected!
                //join statements don't get mapped
                //Target table must be the same as DbSet
            }

            var context2 = new EmployeesDbContext();

            var state3 = context2.Entry(employee).State;
        }

        private static void First()
        {
            var context = new EmployeesDbContext();

            var querry = @"SELECT * FROM Employees WHERE FirstName = {0}";
            var firstName = "Ivan";

            var employees = context.Employees
                    .FromSql(querry, firstName)
                    .ToArray();

            Console.WriteLine(employees.Length);
        }
    }


}
