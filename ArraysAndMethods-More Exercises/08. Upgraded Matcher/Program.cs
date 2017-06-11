using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Inventory_Matcher
{
    class Program
    {
        static void Main(string[] args)
        {
            var namesOfProdcuts = Console.ReadLine().Split().ToArray();
            var quantityOfProductsOld = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();
            var newQuantitiesOfProducts = new long[namesOfProdcuts.Length];
            quantityOfProductsOld.CopyTo(newQuantitiesOfProducts,0);
            var priceInDecimal = Console.ReadLine().Split().Select(decimal.Parse).ToArray();
            var input = string.Empty;
            var firstPartOfInput = string.Empty;
            var secondPartOfInput = string.Empty;
            long quantity = 0;
            long diffrence = 0;
            var iterator = 0;
            while (input != "done")
            {
                iterator++;
                if (iterator != 1)
                {
                    firstPartOfInput = input.Split().First();
                    secondPartOfInput = input.Split().Last();
                    quantity = long.Parse(secondPartOfInput);
                    for (int i = 0; i < namesOfProdcuts.Length; i++)
                    {
                        if (firstPartOfInput == namesOfProdcuts[i])
                        {
                            diffrence = newQuantitiesOfProducts[i] - quantity;
                            if (diffrence < 0) 
                            {
                                Console.WriteLine($"We do not have enough {namesOfProdcuts[i]}");
                            }
                            else
                            {                       
                                Console.WriteLine("{0} x {1} costs {2:f2}",
                                    namesOfProdcuts[i],
                                    quantity,
                                    (priceInDecimal[i]*quantity));
                                newQuantitiesOfProducts[i] -= quantity;
                            }
                        }
                    } 
                }
                input = Console.ReadLine();
            }
        }
    }
}
