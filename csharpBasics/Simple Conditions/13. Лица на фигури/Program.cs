using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Лица_на_фигури
{
    class Program
    {
        static void Main(string[] args)
        {

            string figura = Console.ReadLine();
            double area;
            
            if (figura == "square")
            {
                double strana = double.Parse(Console.ReadLine());
                area = Math.Pow(strana, 2);
                Console.WriteLine("{0}", Math.Round(area, 3));
            }
            else if (figura =="circle")
            {
                double strana = double.Parse(Console.ReadLine());
                area = Math.PI * Math.Pow(strana, 2);
                Console.WriteLine("{0}", Math.Round(area, 3));
            }
            else if (figura =="rectangle")
            {
                double strana1 = double.Parse(Console.ReadLine());
                double strana2 = double.Parse(Console.ReadLine());
                area = strana1 * strana2;
                Console.WriteLine("{0}", Math.Round(area, 3));
            }
            else
            {
                double strana = double.Parse(Console.ReadLine());
                double visochina = double.Parse(Console.ReadLine());
                area = (strana * visochina)/2;
                Console.WriteLine("{0}", Math.Round(area, 3));
            }



        }
    }
}
