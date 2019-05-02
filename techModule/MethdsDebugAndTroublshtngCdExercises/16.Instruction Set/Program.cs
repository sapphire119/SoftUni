using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class InstructionSet_broken
{
    static void Main()
    {
        string opCode = Console.ReadLine();
        while (opCode != "END")
        {

            string[] codeArgs = opCode.Split(' ');
            long result = 0;
            switch (codeArgs[0])
            {
                case "INC":
                    {
                        var operandOne = long.Parse(codeArgs[1]);
                        result = ++operandOne;
                        break;
                    }
                case "DEC":
                    {
                        var operandOne = long.Parse(codeArgs[1]);
                        result = --operandOne;
                        break;
                    }
                case "ADD":
                    {
                        var operandOne = long.Parse(codeArgs[1]);
                        var operandTwo = long.Parse(codeArgs[2]);
                        result = operandOne + operandTwo;
                        break;
                    }
                case "MLA":
                    {
                        checked
                        {
                            var operandOne = long.Parse(codeArgs[1]);
                            var operandTwo = long.Parse(codeArgs[2]);
                            result = (operandOne * operandTwo);
                            break; 
                        }
                    }
            }
            Console.WriteLine(result);
            opCode = Console.ReadLine();
        }
    }
}