using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {


            bool cherveno = bool.Parse(Console.ReadLine());
            bool jalto = bool.Parse(Console.ReadLine());
            

            if(cherveno)
                Console.WriteLine("Stoia");
            if (jalto)
                Console.WriteLine("Prigotviam se");
            else
                Console.WriteLine("Tragvam");
            
        }
    }
}
