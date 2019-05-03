using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Сумиране_на_секунди
{
    class Program
    {
        static void Main(string[] args)
        {

            
            int time1 = int.Parse(Console.ReadLine());
            int time2 = int.Parse(Console.ReadLine());
            int time3 = int.Parse(Console.ReadLine());

            int totaltime = time1 + time2 + time3;
            

            if (totaltime <=59)
            {

                if (totaltime <=9)
                { 
                    Console.WriteLine("0:0{0}",totaltime);
                }
                else
                {
                    Console.WriteLine("0:{0}",totaltime);
                }

            }
            if (totaltime >=60 && totaltime <120 )
            {
                
                if (totaltime <=69)
                {
                    totaltime -= 60;
                    Console.WriteLine("1:0{0}",totaltime);
                }
                else
                {
                    totaltime -= 60;
                    Console.WriteLine("1:{0}",totaltime);
                }

            }
            if (totaltime >=120 && totaltime <180)
            {

                if (totaltime <=129)
                {
                    totaltime -= 120;
                    Console.WriteLine("2:0{0}", totaltime);
                }
                else
                {
                    totaltime -= 120;
                    Console.WriteLine("2:{0}", totaltime);
                }

            }




        }
    }
}
