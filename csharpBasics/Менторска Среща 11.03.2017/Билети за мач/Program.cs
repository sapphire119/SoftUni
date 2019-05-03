using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Билети_за_мач
{
    class Program
    {
        static void Main(string[] args)
        {

            var money = double.Parse(Console.ReadLine());
            var type = Console.ReadLine().ToLower();
            var people = int.Parse(Console.ReadLine());

            double totalTicketSUM = 0;
            double leftSUM = 0;            
            if (type =="normal")
            {
                
                if (people >= 1 && people <= 4)
                {
                    leftSUM = money * 0.75;
                    leftSUM = money - leftSUM;
                    totalTicketSUM = 249.99 * people;
                }
                else if (people >= 5 && people <= 9)
                {
                    leftSUM = money * 0.60;
                    leftSUM = money - leftSUM;
                    totalTicketSUM = 249.99 * people;
                }
                else if (people >= 10 && people <= 24)
                {
                    leftSUM = money * 0.50;
                    leftSUM = money - leftSUM;
                    totalTicketSUM = 249.99 * people;
                }
                else if (people >= 25 && people <= 49)
                {
                    leftSUM = money * 0.40;
                    leftSUM = money - leftSUM;
                    totalTicketSUM = 249.99 * people;
                }
                else if (people >= 50)
                {
                    leftSUM = money * 0.25;
                    leftSUM = money - leftSUM;
                    totalTicketSUM = 249.99 * people;
                }
                
            }
            else if (type =="vip")
            {
                if (people >= 1 && people <= 4)
                {
                    leftSUM = money * 0.75;
                    leftSUM = money - leftSUM;
                    totalTicketSUM = 499.99 * people;
                }
                else if (people >= 5 && people <= 9)
                {
                    leftSUM = money * 0.60;
                    leftSUM = money - leftSUM;
                    totalTicketSUM = 499.99 * people;
                }
                else if (people >= 10 && people <= 24)
                {
                    leftSUM = money * 0.50;
                    leftSUM = money - leftSUM;
                    totalTicketSUM = 499.99 * people;
                }
                else if (people >= 25 && people <= 49)
                {
                    leftSUM = money * 0.40;
                    leftSUM = money - leftSUM;
                    totalTicketSUM = 499.99 * people;
                }
                else if (people >= 50)
                {
                    leftSUM = money * 0.25;
                    leftSUM = money - leftSUM;
                    totalTicketSUM = 499.99 * people;
                }
            }
            double diffrence = 0;
            if (totalTicketSUM<=leftSUM)
            {
                diffrence = leftSUM - totalTicketSUM;
                Console.WriteLine("Yes! You have {0:f2} leva left.",diffrence);
            }
            else
            {
                diffrence = totalTicketSUM - leftSUM;
                Console.WriteLine("Not enough money! You need {0:f2} leva.",diffrence);
            }
        }
    }
}
