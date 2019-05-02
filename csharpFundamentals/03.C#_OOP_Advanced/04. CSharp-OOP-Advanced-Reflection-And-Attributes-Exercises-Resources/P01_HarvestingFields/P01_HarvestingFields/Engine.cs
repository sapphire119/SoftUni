using P01_HarvestingFields;
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
        var type = typeof(HarvestingFields);

        var allFields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

        string command;
        while ((command = reader.ReadLine()) != "HARVEST")
        {
            switch (command)
            {
                case "private":PrinteFields(allFields.Where(f => f.IsPrivate).ToArray()); break;
                case "protected": PrinteFields(allFields.Where(f => f.IsFamily).ToArray()); break;
                case "public": PrinteFields(allFields.Where(f => f.IsPublic).ToArray()); break;
                case "all": PrinteFields(allFields); break;
            }
        }
    }

    private void PrinteFields(FieldInfo[] allfields)
    {
        foreach (var field in allfields)
        {
            var fieldAttribute = field.Attributes.ToString().ToLower();
            if (fieldAttribute == "family") fieldAttribute = "protected";

            var fieldType = field.FieldType.Name;
            var fieldName = field.Name;
            writer.WriteLine($"{fieldAttribute} {fieldType} {fieldName}");
        }
    }
}