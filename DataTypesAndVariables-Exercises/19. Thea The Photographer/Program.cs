using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _19.Thea_The_Photographer
{
    class Program
    {
        static void Main(string[] args)
        {
            long numberOfPictures = long.Parse(Console.ReadLine());
            long filterTime = long.Parse(Console.ReadLine());
            long filterFactor = long.Parse(Console.ReadLine());
            long uploadTime = long.Parse(Console.ReadLine());
            long filteredPictures = (long)Math.Ceiling(numberOfPictures * filterFactor / 100.0);
            long totalTimeForTotalPictures = numberOfPictures * filterTime;
            long totalTimeForFilteredPictures = filteredPictures * uploadTime;
            long totalTime = totalTimeForTotalPictures + totalTimeForFilteredPictures;
            int days = 0;
            int hours = 0;
            int minutes = 0;
            int seconds = 0;
            while (totalTime >= 86400)
            {
                days++;
                totalTime -= 86400;
            }
            while (totalTime >= 3600)
            {
                hours++;
                totalTime -= 3600;
            }
            while (totalTime >= 60)
            {
                minutes++;
                totalTime -= 60;
            }
            seconds = (int)totalTime;
            Console.WriteLine("{0}:{1:d2}:{2:d2}:{3:d2}", days, hours, minutes, seconds);


        }
    }
}
