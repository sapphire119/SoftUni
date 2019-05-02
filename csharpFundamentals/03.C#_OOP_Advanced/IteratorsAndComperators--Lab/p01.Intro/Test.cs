using System;
using System.Collections.Generic;
using System.Text;

namespace p01.Intro
{
    public class Test
    {
        public void Consumer()
        {
            foreach (int i in Integers())
            {
                Console.WriteLine(i.ToString());
            }
        }

        public IEnumerable<int> Integers()
        {
            yield return 1;
            yield return 2;
            yield return 4;
            yield return 8;
            yield return 16;
            yield return 16777216;
        }
    }
}
