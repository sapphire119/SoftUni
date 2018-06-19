using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var bankAccounts = new List<BankAccount>();

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            var args = command.Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries);

            var currentInput = args[0];
            var restOfArgs = args.Skip(1).ToArray();
            switch (currentInput)
            {
                case "Create":Create(bankAccounts,restOfArgs); break;
                case "Deposit": DepositFunds(bankAccounts, restOfArgs);break;
                case "Withdraw":WithdrawFunds(bankAccounts, restOfArgs);break;
                case "Print":Print(bankAccounts, restOfArgs); break;
                default:
                    break;
            }
        }
    }

    private static void Print(List<BankAccount> bankAccounts, string[] restOfArgs)
    {
        if (restOfArgs.Length != 1)
        {
            return;
        }

        var currentId = int.Parse(restOfArgs[0]);
        var currentBankAccount = bankAccounts.Find(b => b.Id == currentId);
        if (currentBankAccount == null)
        {
            Console.WriteLine("Account does not exist");
            return;
        }

        Console.WriteLine(currentBankAccount);
    }

    private static void WithdrawFunds(List<BankAccount> bankAccounts, string[] restOfArgs)
    {
        if (restOfArgs.Length != 2)
        {
            return;
        }

        var currentId = int.Parse(restOfArgs[0]);
        var withdrawAmount = decimal.Parse(restOfArgs[1]);

        var currentBankAccount = bankAccounts.Find(b => b.Id == currentId);
        if (currentBankAccount == null)
        {
            Console.WriteLine("Account does not exist");
            return;
        }

        if (withdrawAmount > currentBankAccount.Balance)
        {
            Console.WriteLine("Insufficient balance");
            return;
        }
        currentBankAccount.Withdraw(withdrawAmount);
    }

    private static void DepositFunds(List<BankAccount> bankAccounts, string[] restOfArgs)
    {
        if (restOfArgs.Length != 2)
        {
            return;
        }

        var currentId = int.Parse(restOfArgs[0]);
        var depositAmount = decimal.Parse(restOfArgs[1]);

        var currentBankAccount = bankAccounts.Find(b => b.Id == currentId);
        if (currentBankAccount == null)
        {
            Console.WriteLine("Account does not exist");
            return;
        }
        currentBankAccount.Deposit(depositAmount);
    }

    private static void Create(List<BankAccount> bankAccounts, string[] restOfArgs)
    {
        if (restOfArgs.Length != 1)
        {
            return;
        }

        var currentId = int.Parse(restOfArgs[0]);

        var existingAccount = bankAccounts.Find(ba => ba.Id == currentId);
        if (existingAccount != null)
        {
            Console.WriteLine($"Account already exists");
            return;
        }

        var bankAccount = new BankAccount();
        bankAccount.Id = currentId;

        bankAccounts.Add(bankAccount);
    }
}

