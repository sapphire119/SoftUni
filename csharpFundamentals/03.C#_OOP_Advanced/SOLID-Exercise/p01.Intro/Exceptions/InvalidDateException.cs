using System;
using System.Collections.Generic;
using System.Text;

namespace p01.Intro.Exceptions
{
    public class InvalidDateException : ArgumentException
    {
        public override string Message => "Invalid date!";
    }
}
