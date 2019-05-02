namespace p05.PizzaCalories
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            checked
            {

                var pizzaInput = Console.ReadLine().Split(" ".ToCharArray());
                var doughInput = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                var dough = MakeTheDough(doughInput.Skip(1).ToArray());

                var pizza = MakeThePizza(pizzaInput[1], dough);//new Pizza(pizzaInput[1], dough);

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    var tokens = command.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    var topping = PutTopping(tokens.Skip(1).ToArray());
                    if (topping != null)
                    {
                        try
                        {
                            pizza.AddTopping(topping);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            return;
                        }
                    }
                }

                Console.WriteLine(pizza);
            }
        }

        private static Pizza MakeThePizza(string pizzaName, Dough dough)
        {
            var pizza = new Pizza();
            try
            {
                pizza = new Pizza(pizzaName, dough);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }
            return pizza;
        }

        private static Topping PutTopping(string[] toppingTokens)
        {
            var topping = new Topping();
            try
            {
                var toppingType = toppingTokens[0];
                var weight = decimal.Parse(toppingTokens[1]);

                topping = new Topping(toppingType, weight);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }

            return topping;
        }

        private static Dough MakeTheDough(string[] doughTokens)
        {
            var dough = new Dough();

            try
            {
                var type = doughTokens[0];
                var bakingTechnique = doughTokens[1];
                var weight = decimal.Parse(doughTokens[2]);

                dough = new Dough(weight, bakingTechnique, type);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(0);
            }

            return dough;
        }
    }
}
