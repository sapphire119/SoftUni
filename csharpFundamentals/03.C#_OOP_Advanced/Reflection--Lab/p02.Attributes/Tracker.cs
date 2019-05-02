using p02.Attributes;
using System;
using System.Linq;
using System.Reflection;

public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        var type = typeof(Startup);

        var allMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

        foreach (var methodInfo in allMethods)
        {
            var customAttributes = methodInfo.GetCustomAttributes<SoftUniAttribute>().ToArray();
            foreach (var attribute in customAttributes)
            {
                Console.WriteLine(attribute.Name);
            }
        }
    }
}