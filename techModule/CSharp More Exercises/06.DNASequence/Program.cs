using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.DNASequence
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());

            var sum = 0;
            var iterator = 0;
            for (char i = 'A'; i <= 'T'; i++)
            {
                for (char j = 'A'; j <= 'T'; j++)
                {
                    for (char k = 'A'; k <= 'T'; k++)
                    {
                        if ((k == 'A' || k == 'C' || k == 'G' || k == 'T') &&
                    (j == 'A' || j == 'C' || j == 'G' || j == 'T') &&
                    (i == 'A' || i == 'C' || i == 'G' || i == 'T'))
                        {
                            sum = 0;
                            switch (i)
                            {
                                case 'A': sum += 1; break;
                                case 'C': sum += 2; break;
                                case 'G': sum += 3; break;
                                case 'T': sum += 4; break;
                                default:
                                    break;
                            }
                            switch (j)
                            {
                                case 'A': sum += 1; break;
                                case 'C': sum += 2; break;
                                case 'G': sum += 3; break;
                                case 'T': sum += 4; break;
                                default:
                                    break;
                            }
                            switch (k)
                            {
                                case 'A': sum += 1; break;
                                case 'C': sum += 2; break;
                                case 'G': sum += 3; break;
                                case 'T': sum += 4; break;
                                default:
                                    break;
                            }
                            if (sum >= input)
                            {
                                iterator++;
                                Console.Write("O{0}{1}{2}O ",i,j,k);

                            }
                            else
                            {
                                iterator++;
                                Console.Write("X{0}{1}{2}X ", i, j, k);
                            }
                            sum = 0;

                            if (iterator % 4 == 0)
                            {
                                Console.WriteLine();
                            }
                            




                        }
                    }
                }
            }
        }
    }
}
    