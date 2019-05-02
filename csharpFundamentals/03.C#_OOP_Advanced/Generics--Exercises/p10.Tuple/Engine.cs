using System;
using System.Collections.Generic;

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
        var personInfoInput = reader.SplitLine();
        PrintPersonAddress(personInfoInput);
        
        var personNameBeerLitres = reader.SplitLine();
        PrintPersonBeer(personNameBeerLitres);
       
        var valuesInput = reader.SplitLine();
        PrintValues(valuesInput);
        
    }

    private void PrintValues(string[] valuesInput)
    {
        var integer = int.Parse(valuesInput[0]);
        var @double = double.Parse(valuesInput[1]);

        var values = new Tuple<int, double>(integer, @double);

        writer.WriteLine($"{values.Item1} -> {values.Item2}");
    }

    private void PrintPersonBeer(string[] personNameBeerLitres)
    {
        var beerPerson = personNameBeerLitres[0];
        var litresBeer = int.Parse(personNameBeerLitres[1]);

        var personBeer = new Tuple<string, int>(beerPerson, litresBeer);

        writer.WriteLine($"{personBeer.Item1} -> {personBeer.Item2}");
    }

    private void PrintPersonAddress(string[] personInfoInput)
    {
        var personName = string.Concat(personInfoInput[0], " ", personInfoInput[1]);
        var address = personInfoInput[2];


        var personInfo = new Tuple<string, string>(personName, address);

        writer.WriteLine($"{personInfo.Item1} -> {personInfo.Item2}");
    }
}