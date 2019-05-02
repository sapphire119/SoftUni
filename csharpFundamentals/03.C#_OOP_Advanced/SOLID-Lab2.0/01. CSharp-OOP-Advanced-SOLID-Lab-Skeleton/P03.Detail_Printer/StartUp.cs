namespace P03.DetailPrinter
{
    using P03.Detail_Printer;
    using P03.Detail_Printer.Abstracts;
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            Employee employee = new Employee("Pesho");
            Employee employee2 = new Employee("Ivan");
            Employee employee3 = new Employee("Gosho");
            Employee employee4 = new Employee("Dobromir");

            List<string> documents = new List<string>();
            documents.Add("vajno");
            documents.Add("mnogo vajno");
            documents.Add("reshi me");
            documents.Add("da e gotovo");

            Manager manager = new Manager("Viskozii", documents);

            Developer developer = new Developer("Nqma znachenie", "C#");

            List<Worker> workers = new List<Worker>();

            workers.Add(employee);
            workers.Add(employee2);
            workers.Add(employee3);
            workers.Add(employee4);
            workers.Add(manager);
            workers.Add(developer);

            DetailsPrinter printer = new DetailsPrinter(workers);

            printer.PrintDetails();
        }
    }
}
