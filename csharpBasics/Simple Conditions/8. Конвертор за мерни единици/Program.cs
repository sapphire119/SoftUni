using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8.Конвертор_за_мерни_единици
{
    class Program
    {
        static void Main(string[] args)
        {


            double dist = double.Parse(Console.ReadLine());
            string ed1 = Console.ReadLine();
            string ed2 = Console.ReadLine();

            

            if (ed1 == "m")
            {

                if (ed2 =="km")
                {

                    dist = dist / 1000;
                    Console.WriteLine("{0}",dist);
                }
                else if (ed2 =="cm")
                {
                    dist = dist * 100;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 =="mm")
                {
                    dist = dist * 1000;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "mi")
                {
                    dist = dist* 0.0006213711920;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2=="in")
                {
                    dist = dist * 39.3700787;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2=="ft")
                {
                    dist = dist * 3.2808399;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2=="yd")
                {
                    dist = dist * 1.0936133;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2=="m")
                {
                    Console.WriteLine("{0}", dist);
                }

            }
            else if (ed1=="km")
            {
                if (ed2 == "m")
                {

                    dist = dist*1000;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "cm")
                {
                    dist = dist * 100000;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "mm")
                {
                    dist = dist * 1000000;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "mi")
                {
                    dist = dist * 0.621371192;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "in")
                {
                    dist = dist * 39370.0787;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "ft")
                {
                    dist = dist * 3280.8399;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "yd")
                {
                    dist = dist * 1093.6133;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "km")
                {
                    Console.WriteLine("{0}", dist);
                }

            }
            else if (ed1 == "cm")
            {
                if (ed2 == "km")
                {

                    dist = dist / 100000;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "m")
                {
                    dist = dist/100;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "mm")
                {
                    dist = dist * 10;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "mi")
                {
                    dist = dist * 0.000006213711920;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "in")
                {
                    dist = dist * 0.393700787;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "ft")
                {
                    dist = dist * 0.032808399;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "yd")
                {
                    dist = dist * 0.010936133;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "cm")
                {
                    Console.WriteLine("{0}", dist);
                }

            }
            else if (ed1=="mm")
            {
                if (ed2 =="km")
                {

                    dist = dist / 1000000;
                    Console.WriteLine("{0}",dist);
                }
                else if (ed2 =="cm")
                {
                    dist = dist/10;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 =="m")
                {
                    dist = dist/1000;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "mi")
                {
                    dist = dist* 0.0000006213711920;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2=="in")
                {
                    dist = dist * 0.0393700787;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2=="ft")
                {
                    dist = dist * 0.0032808399;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2=="yd")
                {
                    dist = dist * 0.0010936133;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "mm")
                {
                    Console.WriteLine("{0}", dist);
                }

            }
            else if (ed1=="mi")
            {
                if (ed2 == "km")
                {

                    dist = dist* 1.609344;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "cm")
                {
                    dist = dist * 160934.4;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "mm")
                {
                    dist = dist * 1609344;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "m")
                {
                    dist = dist * 1609.344;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "in")
                {
                    dist = dist * 63360;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "ft")
                {
                    dist = dist * 5280;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "yd")
                {
                    dist = dist *1760;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "mi")
                {
                    Console.WriteLine("{0}", dist);
                }
            }
            else if (ed1=="in")
            {
                if (ed2 == "km")
                {

                    dist = dist * 0.0000254000508001016002032004064008;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "cm")
                {
                    dist = dist * 2.54;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "mm")
                {
                    dist = dist * 25.4;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "m")
                {
                    dist = dist *0.0254;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "mi")
                {
                    dist = dist * 0.0000157828283;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "ft")
                {
                    dist = dist * 0.083333333333;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "yd")
                {
                    dist = dist * 0.027778;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "in")
                {
                    Console.WriteLine("{0}", dist);
                }

            }
            else if (ed1=="ft")
            {

                if (ed2 == "km")
                {

                    dist = dist/ 3280.8398999999946468738452480744;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "cm")
                {
                    dist = dist * 30.48;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "mm")
                {
                    dist = dist * 304.8;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "m")
                {
                    dist = dist * 0.3048;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "mi")
                {
                    dist = dist * 0.00018939;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "in")
                {
                    dist = dist * 12;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "yd")
                {
                    dist = dist * 0.33333;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "ft")
                {
                    Console.WriteLine("{0}", dist);
                }


            }
            else if (ed1=="yd")
            {

                if (ed2 == "km")
                {

                    dist = dist / 1093.6132999999994999849061540233;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "cm")
                {
                    dist = dist/0.01093613300000000743866763548088;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "mm")
                {
                    dist = dist/0.00109361330000000041100932848174;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "m")
                {
                    dist = dist/1.093613300000000066472685167452;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "mi")
                {
                    dist = dist * 0.00056818;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "in")
                {
                    dist = dist * 36;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "ft")
                {
                    dist = dist *3;
                    Console.WriteLine("{0}", dist);
                }
                else if (ed2 == "yd")
                {
                    Console.WriteLine("{0}", dist);
                }


            }




        }
    }
}
