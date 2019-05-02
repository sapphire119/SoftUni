using System;
using System.Collections.Generic;
using System.Text;

namespace p01.Intro
{
    public class TestReflection
    {
        private TestReflection(double ivanSki)
        {

        }

        public TestReflection(int number)
        {
            this.number = number;
        }

        protected TestReflection(string name, int age)
        {

        }

        private TestReflection(int number1, int number2, params string[] names)
        {

        }

        //public TestReflection()
        //{

        //}


        private static string privateString;
        public static int publicInt;

        public int age; //Инстанце полета
        private string name; //инстанце полета

        public string TestProp { get; set; }

        private int number;

        public int Number => this.number;


        public TestReflection() { }
    }
}
