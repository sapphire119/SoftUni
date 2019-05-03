using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Рибна_Борса
{
    class Program
    {
        static void Main(string[] args)
        {
            var skumriq = double.Parse(Console.ReadLine());
            var caca = double.Parse(Console.ReadLine());
            var palamudKG = double.Parse(Console.ReadLine());
            var safridKG = double.Parse(Console.ReadLine());
            int midiKG = int.Parse(Console.ReadLine());


            var cenaPalamud = skumriq + (skumriq * 0.60);
            var cenaSafrid = caca + (caca * 0.80);

            cenaPalamud = palamudKG * cenaPalamud;
            cenaSafrid = safridKG * cenaSafrid;

            var midiCena = midiKG * 7.50;

            var total = midiCena + cenaSafrid + cenaPalamud;

            Console.WriteLine("{0:f2}",total);

        }
    }
}
