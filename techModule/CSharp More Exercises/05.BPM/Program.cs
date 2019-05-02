using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.BPM
{
    class Program
    {
        static void Main(string[] args)
        {
            var bpm = int.Parse(Console.ReadLine());
            var beats = int.Parse(Console.ReadLine());

            var bars = beats / 4.0;
            bars = Math.Round(bars, 1);

            var SecondSum = (beats / (double)bpm) * 60;
            SecondSum = Math.Truncate(SecondSum);
            var seconds = SecondSum % 60;
            int minutes = (int)SecondSum / 60;
            Console.WriteLine($"{bars} bars - {minutes}m {seconds}s");
        }
    }
}
