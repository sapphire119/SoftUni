using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Триъгълник_от_долари
{
    class Program
    {
        static void Main(string[] args)
        {

            int tableSize = int.Parse(Console.ReadLine());

            for (int row = 1; row <= tableSize; row++)
            {
                int numberToPrint = row;
                bool isMaxNumberPrinted = false;
                for(int col=1;col<=tableSize;col++)
                {
                    Console.Write("{0} ", numberToPrint);
                    if (numberToPrint == tableSize)
                        isMaxNumberPrinted = true;

                    if (isMaxNumberPrinted)
                    {
                        numberToPrint--;
                    }
                    else
                    {
                        numberToPrint++;
                    }
                }
                Console.WriteLine();
            }

        } 
    }
}
