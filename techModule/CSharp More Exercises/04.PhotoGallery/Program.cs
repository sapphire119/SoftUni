using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PhotoGallery
{
    class Program
    {
        static void Main(string[] args)
        {
            var PhotoNumber = int.Parse(Console.ReadLine());
            var day = int.Parse(Console.ReadLine());
            var month= int.Parse(Console.ReadLine());
            var year = int.Parse(Console.ReadLine());
            var hours= int.Parse(Console.ReadLine());
            var minutes= int.Parse(Console.ReadLine());
            var bytes= int.Parse(Console.ReadLine());
            var width= int.Parse(Console.ReadLine());
            var height= int.Parse(Console.ReadLine());

            Console.WriteLine($"Name: DSC_{PhotoNumber:d4}.jpg");
            Console.WriteLine("Date Taken: {0:d2}/{1:d2}/{2:d4} {3:d2}:{4:d2}",day,month,year,hours,minutes);
            if (bytes<1000)
            {
                Console.WriteLine("Size: {0}B",bytes);
            }
            else if (bytes>=1000 && bytes<1000000)
            {
                Console.WriteLine("Size: {0}KB", bytes/1000.0);
            }
            else if (bytes >= 1000000)
            {
                Console.WriteLine("Size: {0}MB", bytes / 1000000.0);
            }
            if (width ==height)
            {
                Console.WriteLine("Resolution: {0}x{1} (square)", width, height);
            }
            else if (width>height)
            {
                Console.WriteLine("Resolution: {0}x{1} (landscape)", width, height);
            }
            else if (width<height)
            {
                Console.WriteLine("Resolution: {0}x{1} (portrait)", width, height);
            }
        }
    }
}
