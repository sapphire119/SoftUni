using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace упр_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Докато имам следващ ред го прочитам.

            int numberofWords = int.Parse(Console.ReadLine());
            //numberofWords>0 //bool hasNextRow = true;
            while (numberofWords>0)
            {     //Това е за True case
                //Четем реда
                Console.WriteLine("Прочетох реда" );
                numberofWords = int.Parse(Console.ReadLine());
                //hasNextRow = numberofWords > 0;
            }
            Console.WriteLine("Прочетох стрницатя");

        }

    }
}
