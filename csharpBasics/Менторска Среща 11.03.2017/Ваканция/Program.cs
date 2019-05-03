using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ваканция
{
    class Program
    {
        static void Main(string[] args)
        {
            var Oldpeople = int.Parse(Console.ReadLine());
            var students = int.Parse(Console.ReadLine());
            var nightsHotel = int.Parse(Console.ReadLine());
            var transportation = Console.ReadLine().ToLower();
            var sumPeople = Oldpeople + students;
            double CostTransport;
            double CostHotel;
            double Commission;
            double TotalSum;
            if (transportation=="train")
            {
                CostTransport = (Oldpeople * 24.99 + students * 14.99) * 2;
                if (sumPeople>=50)
                {
                    CostTransport = CostTransport * 0.50;
                }
                CostHotel = nightsHotel * 82.99;
                Commission = (CostTransport + CostHotel) * 0.10;
                TotalSum = CostTransport + CostHotel + Commission;
                Console.WriteLine("{0:f2}", TotalSum);
            }
            else if (transportation=="bus")
            {
                CostTransport = (Oldpeople * 32.50 + students * 28.50) * 2;
                CostHotel = nightsHotel * 82.99;
                Commission = (CostTransport + CostHotel) * 0.10;
                TotalSum = CostTransport + CostHotel + Commission;
                Console.WriteLine("{0:f2}", TotalSum);
            }
            else if (transportation=="boat")
            {

                CostTransport = (Oldpeople * 42.99 + students * 39.99) * 2;
                CostHotel = nightsHotel * 82.99;
                Commission = (CostTransport + CostHotel) * 0.10;
                TotalSum = CostTransport + CostHotel + Commission;
                Console.WriteLine("{0:f2}", TotalSum);
            }
            else if (transportation=="airplane")
            {

                CostTransport = (Oldpeople * 70.00 + students * 50.00) * 2;
                CostHotel = nightsHotel * 82.99;
                Commission = (CostTransport + CostHotel) * 0.10;
                TotalSum = CostTransport + CostHotel + Commission;
                Console.WriteLine("{0:f2}", TotalSum);
            }

            
        }
    }
}
