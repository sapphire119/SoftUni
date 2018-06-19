using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

public class Spy
{
    public string AnalyzeAcessModifiers(string className)
    {
        StringBuilder sb = new StringBuilder();

        var classType = Type.GetType(className);

        var allFields = classType.GetFields();

        //var allMethods = classType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
        var allProperties = classType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        ;
        foreach (var field in allFields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (var property in allProperties)
        {
            if (property.GetMethod?.IsPrivate == true)
                sb.AppendLine($"{property.GetMethod.Name} have to be public!");

            if (property.SetMethod?.IsPublic == true)
                sb.AppendLine($"{property.SetMethod.Name} have to be private!");
        }

        return sb.ToString().TrimEnd();
    }

    public string StealFieldInfo(string className, params string[] fieldsToInvestigate)
    {
        StringBuilder sb = new StringBuilder();

        var classType = Type.GetType(className);

        sb.AppendLine($"Class under investigation: {className}");

        var allFields = classType.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

        var classInstance = Activator.CreateInstance(Type.GetType(className));

        foreach (var item in allFields)
        {
            if (fieldsToInvestigate.Contains(item.Name))
            {
                object localValue = item.GetValue(classInstance);
                sb.AppendLine($"{item.Name} = {localValue}");
            }
        }

        return sb.ToString().TrimEnd();
    }

    public string RevealPrivateMethods(string className)
    {
        StringBuilder sb = new StringBuilder($"All Private Methods of Class: {className}" + Environment.NewLine);

        Type type = Type.GetType(className);
        sb.AppendLine($"Base Class: {type.BaseType.Name}");

        var privateMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (var privateMethod in privateMethods)
        {
            sb.AppendLine($"{privateMethod.Name}");
        }

        var result = sb.ToString().TrimEnd();
        return result;
    }

    public string CollectGettersAndSetters(string className)
    {
        StringBuilder sb = new StringBuilder();

        Type classType = Type.GetType(className);

        var allMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);

        foreach (var method in allMethods)
        {
            if (method.Name.StartsWith("get"))
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
        }
        ;
        foreach (var method in allMethods)
        {
            if (method.Name.StartsWith("set"))
            {
                var parameter = method.GetParameters().First();
                sb.AppendLine($"{method.Name} will set field of {parameter.ParameterType}");

            }
        }

        var result = sb.ToString().TrimEnd();

        return result;
    }
    
    public Courses Courses { get; set; }
}

[Flags]
public enum Courses
{
    None = 0,
    CSharpAdvanced = 1,
    DataStructures = 2,
    DB = 4,
    JS = 8,
    Web = 16,
    FrontEnd = JS | Web
}