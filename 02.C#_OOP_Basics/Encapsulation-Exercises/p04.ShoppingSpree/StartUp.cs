namespace p04.ShoppingSpree
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var peopleMoney = Console.ReadLine().Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var productsCost = Console.ReadLine().Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            var people = new List<Person>();
            var products = new List<Product>();

            GetPeople(peopleMoney, people);
            GetProducts(productsCost, products);

            BuyProducts(people, products);
            PrintOutput(people);
        }

        private static void PrintOutput(List<Person> people)
        {
            Console.WriteLine(string.Join(Environment.NewLine, people));
        }

        private static void BuyProducts(List<Person> people, List<Product> products)
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                var tokens = command.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                var personName = tokens[0];
                var productName = tokens[1];

                var existingPerson = people.Find(p => p.Name == personName);
                if (existingPerson == null)
                {
                    continue;
                }

                var existingProduct = products.Find(p => p.Name == productName);
                if (existingPerson == null)
                {
                    continue;
                }

                var diffrence = existingPerson.Money - existingProduct.Cost;
                if (diffrence < 0M)
                {
                    Console.WriteLine($"{personName} can't afford {productName}");
                }
                else
                {
                    existingPerson.Money = diffrence;
                    existingPerson.AddProduct(existingProduct);
                    Console.WriteLine($"{personName} bought {productName}");
                }
            }
        }

        private static void GetProducts(string[] productsCost, List<Product> products)
        {
            foreach (var productCost in productsCost)
            {
                var productWithMoney = productCost.Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                var productName = productWithMoney[0];
                var money = decimal.Parse(productWithMoney[1]);

                var product = new Product();
                try
                {
                    product = new Product(productName, money);
                    products.Add(product);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
            }
        }

        private static void GetPeople(string[] peopleMoney, List<Person> people)
        {
            foreach (var personMoney in peopleMoney)
            {
                var personWithMoney = personMoney.Split("=".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                var currentPersonName = personWithMoney[0];
                var money = decimal.Parse(personWithMoney[1]);

                var person = new Person();
                try
                {
                    person = new Person(currentPersonName, money);
                    people.Add(person);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Environment.Exit(0);
                }
            }
        }
    }
}
