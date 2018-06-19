using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задача_3.Навреме_за_изпит
{
    class Program
    {
        static void Main(string[] args)
        {

            int hour1 = int.Parse(Console.ReadLine());
            int min1 = int.Parse(Console.ReadLine());

            int hour2 = int.Parse(Console.ReadLine());
            int min2 = int.Parse(Console.ReadLine());


            int exam = hour1 * 60 + min1;
            //Console.WriteLine(exam);
            int arriving = hour2 * 60 + min2;
            //Console.WriteLine(arriving);
            int diffrence = arriving - exam;
            //Console.WriteLine(diffrence);
            double chasove;
            double minuti;
            if (diffrence <= 0 && diffrence >= -30)
            {

                if (diffrence == 0)
                {
                    Console.WriteLine("On Time");
                }
                else if (diffrence < 0 && diffrence >= -30)
                {
                    Console.WriteLine("on time {0} minutes before the start ", Math.Abs(diffrence));
                }
            }
            else if (diffrence < -30)
            {
                Console.WriteLine("early {0} minutes before the start", Math.Abs(diffrence));
                if (Math.Abs(diffrence) < 30 && Math.Abs(diffrence) < 59)
                {
                    Console.WriteLine("early {0} minutes before the start", Math.Abs(diffrence));
                }
                else if (Math.Abs(diffrence) > 59)
                {

                    //Console.WriteLine(diffrence);
                    chasove = Math.Abs(diffrence / 60);
                    minuti = Math.Abs(diffrence) - chasove * 60;
                    if (minuti >= 0 && minuti <= 9)
                    {
                        Console.WriteLine("early {0}:0{1} hours before the start ", chasove, minuti);
                    }
                    else if (minuti > 9)
                    {
                        Console.WriteLine("early {0}:{1} hours before the start ", chasove, minuti);
                    }
                }


            }
            else if (diffrence >= 0)
            {

                if (Math.Abs(diffrence) <= 59)
                {
                    Console.WriteLine("late {0} minutes after the start", Math.Abs(diffrence));
                }
                else if (Math.Abs(diffrence) > 59)
                {

                    //Console.WriteLine(diffrence);
                    chasove = Math.Abs(diffrence / 60);
                    minuti = Math.Abs(diffrence) - chasove * 60;
                    if (minuti >= 0 && minuti <= 9)
                    {
                        Console.WriteLine("late {0}:0{1} hours after the start ", chasove, minuti);
                    }
                    else if (minuti > 9)
                    {
                        Console.WriteLine("late {0}:{1} hours after the start ", chasove, minuti);
                    }
                }

            }
            else
            {
                Console.WriteLine("error");
            }


        }

    }
}


