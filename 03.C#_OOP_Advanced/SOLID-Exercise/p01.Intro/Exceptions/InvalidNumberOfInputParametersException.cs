using System;
using System.Collections.Generic;
using System.Text;

namespace p01.Intro.Exceptions
{
    public class InvalidNumberOfInputParametersException : ArgumentException
    {
        public override string Message => "Input parameters must be 3!";
    }
}
