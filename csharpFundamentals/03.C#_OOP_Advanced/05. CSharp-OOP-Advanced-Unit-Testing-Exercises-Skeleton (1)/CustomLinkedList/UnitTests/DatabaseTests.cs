using System.Reflection;
using NUnit.Framework;
using System;
using System.Linq;
using p01.Database;
using Moq;

namespace UnitTests
{
    public class DatabaseTests
    {
        [Test]
        public void ArrayCapacity_Returns16_True()
        {
            var type = typeof(Database);

            var constructor = type.GetConstructor(new Type[] { typeof(int[]) });


        }
    }
}
