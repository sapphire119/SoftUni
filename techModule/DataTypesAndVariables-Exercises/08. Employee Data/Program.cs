using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Employee_Data
{
    class Program
    {
        static void Main(string[] args)
        {
            //First name: Amanda
            //Last name: Jonson
            //Age: 27
            //Gender: f
            //Personal ID: 8306112507
            //Unique Employee number: 27563571

            string name = Console.ReadLine();
            string lastName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            char gender = char.Parse(Console.ReadLine());
            ulong id = ulong.Parse(Console.ReadLine());
            int uniqueEmpyeeNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("First name: {0}",name);
            Console.WriteLine("Last name: {0}",lastName);
            Console.WriteLine("Age: {0}",age);
            Console.WriteLine("Gender: {0}",gender);
            Console.WriteLine("Personal ID: {0}",id);
            Console.WriteLine("Unique Employee number: {0}",uniqueEmpyeeNumber);
        }
    }
}
