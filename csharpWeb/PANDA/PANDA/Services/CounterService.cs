using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Panda.Services
{
    public class CounterService : ICounterService
    {
        public static int count = 0;

        public CounterService()
        {
            count++;
        }

        public int GetCount()
        {
            return count;
        }
    }
}
