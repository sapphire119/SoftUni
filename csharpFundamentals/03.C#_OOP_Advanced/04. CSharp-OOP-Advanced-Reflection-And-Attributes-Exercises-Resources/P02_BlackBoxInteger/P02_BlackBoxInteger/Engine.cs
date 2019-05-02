using P02_BlackBoxInteger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class Engine
{
    private readonly Reader reader;
    private readonly Writer writer;

    public Engine()
    {
        this.reader = new Reader();
        this.writer = new Writer();
    }

    public void Run()
    {
        var type = typeof(BlackBoxInteger);

        Type[] paramTypes = new Type[] { typeof(int) };
        object[] paramValues = new object[] { 0 };

        var constructor = type.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, paramTypes, null);
        var instance = constructor.Invoke(paramValues);

        var allMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        var field = type.GetField("innerValue", BindingFlags.Instance | BindingFlags.NonPublic);

        string command;
        while ((command = reader.ReadLine()) != "END")
        {
            string[] commandArgs = command.Split('_', StringSplitOptions.RemoveEmptyEntries);

            string currentCommand = commandArgs[0];
            switch (currentCommand)
            {
                case "Add":InvokeMethod(instance, commandArgs[1], allMethods.Where(m => m.Name == "Add").First(), field); break;
                case "Subtract":InvokeMethod(instance, commandArgs[1], allMethods.Where(m => m.Name == "Subtract").First(), field);break;
                case "Multiply": InvokeMethod(instance, commandArgs[1], allMethods.Where(m => m.Name == "Multiply").First(), field); break;
                case "Divide": InvokeMethod(instance, commandArgs[1], allMethods.Where(m => m.Name == "Divide").First(), field); break;
                case "LeftShift": InvokeMethod(instance, commandArgs[1], allMethods.Where(m => m.Name == "LeftShift").First(), field); break;
                case "RightShift": InvokeMethod(instance, commandArgs[1], allMethods.Where(m => m.Name == "RightShift").First(), field); break;
            }
        }
    }

    private void InvokeMethod(object instance, string value, MethodInfo methodInfo, FieldInfo field)
    {
        var number = int.Parse(value);
        methodInfo.Invoke(instance, new object[] { number });
        writer.WriteLine(field.GetValue(instance));
    }
}