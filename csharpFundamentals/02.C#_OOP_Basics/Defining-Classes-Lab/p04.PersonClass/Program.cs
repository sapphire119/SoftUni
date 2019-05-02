using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        var bankAccount = new BankAccount(1, 532);
        var bankAccount2 = new BankAccount(2, 246);
        var bankAccount3 = new BankAccount(3, 312);
        var bankAccount4 = new BankAccount(4, 135);
        var bankAccount5 = new BankAccount(5, 321);

        var accounts = new List<BankAccount>();
        accounts.Add(bankAccount);
        accounts.Add(bankAccount2);
        accounts.Add(bankAccount3);
        accounts.Add(bankAccount4);
        accounts.Add(bankAccount5);

        var person = new Person("Pesho", 23, accounts);

        Console.WriteLine($"Total Balance: {person.GetBalance():F2}");
    }
}

