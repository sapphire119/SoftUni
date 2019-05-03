using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace упрж_6
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < 6; i++)
            {
                Console.Write("Цвят на дрехата: ");
                string cvqt = Console.ReadLine().ToLower();
                //Ако дрехата е червена прескочи и продължи
                if (cvqt == "chervena" || cvqt == "red" || cvqt=="червен" )
                    continue;
                Console.WriteLine(cvqt);
            }

        }
    }
}
