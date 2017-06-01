using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18.Different_Integers_Size
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            try
            {
                long input = long.Parse(num);
                var canFitIn = "";
                bool fitsSByte =(input >=sbyte.MinValue &&  input <= sbyte.MaxValue) ? true : false;
                bool fitsByte = (input >= byte.MinValue && input <= byte.MaxValue) ? true : false;
                bool fitsShort = (input >= short.MinValue && input <= short.MaxValue) ? true : false;
                bool fitsUShort = (input >= ushort.MinValue && input <= ushort.MaxValue) ? true : false;
                bool fitsInt = (input >= int.MinValue && input <= int.MaxValue) ? true : false;
                bool fitsUInt = (input >= uint.MinValue && input <= uint.MaxValue) ? true : false;
                bool fitsLong = (input >= long.MinValue && input <= long.MaxValue) ? true : false;


                if (canFitIn != "can't fit in any type\n")
                {
                    Console.WriteLine("{0} can fit in:", input);
                    Console.WriteLine("{0}", canFitIn);
                }
                
            }
            catch
            {
                Console.WriteLine(num);
                Console.WriteLine("can't fit in any type");
            }





        }
    }
}
