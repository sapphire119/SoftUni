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
       
        var bankValuesInput = reader.SplitLine();
        PrintBankDetails(bankValuesInput);
        
    }

    private void PrintBankDetails(string[] bankValuesInput)
    {
        var personName = bankValuesInput[0];
        var balance = double.Parse(bankValuesInput[1]);
        var bankName = bankValuesInput[2];


        var values = new Threeuple<string, double, string>(personName, balance, bankName);

        writer.WriteLine($"{values.Item1} -> {values.Item2} -> {values.Item3}");
    }

    private void PrintPersonBeer(string[] personNameBeerLitres)
    {
        var beerPerson = personNameBeerLitres[0];
        var litresBeer = int.Parse(personNameBeerLitres[1]);
        var isDrunk = personNameBeerLitres[2] == "drunk" ? true : false;

        var personBeer = new Threeuple<string, int, bool>(beerPerson, litresBeer, isDrunk);

        writer.WriteLine($"{personBeer.Item1} -> {personBeer.Item2} -> {personBeer.Item3}");
    }

    private void PrintPersonAddress(string[] personInfoInput)
    {
        var personName = string.Concat(personInfoInput[0], " ", personInfoInput[1]);
        var address = personInfoInput[2];
        var town = personInfoInput[3];


        var personInfo = new Threeuple<string, string, string>(personName, address, town);

        writer.WriteLine($"{personInfo.Item1} -> {personInfo.Item2} -> {personInfo.Item3}");
    }
}