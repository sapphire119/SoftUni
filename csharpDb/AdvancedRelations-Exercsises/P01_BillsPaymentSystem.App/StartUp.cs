namespace P01_BillsPaymentSystem.App
{
    using System;
    using System.Linq;
    using System.Globalization;

    using P01_BillsPaymentSystem.Data;
    using P01_BillsPaymentSystem.Data.Models;

    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        static void Main(string[] args)
        {
            using (var context = new BillsPaymentSystemContext())
            {
                //ResetDatabase(context); //<--- за 2ра задача вътре има и InitialSeed метод.

                var userId = int.Parse(Console.ReadLine());

                //3та задача от тук надолу

                //var user = context.Users
                //    .Where(u => u.UserId == userId)
                //    .Select(u => new
                //    {
                //        FullName = $"{u.FirstName} {u.LastName}",
                //        CreditCards = u.PaymentMethods
                //        .Where(pm => pm.Type == PaymentMethodType.CreditCard)
                //        .Select(pm => pm.CreditCard).ToList(),
                //        BankAccounts = u.PaymentMethods
                //        .Where(pm => pm.Type == PaymentMethodType.BankAccount)
                //        .Select(pm => pm.BankAccount).ToList()
                //    })
                //.FirstOrDefault();

                //Console.WriteLine($"User: {user.FullName}");
                //var creditCards = user.CreditCards;
                //var bankAccounts = user.BankAccounts;
                //if (bankAccounts.Any())
                //{
                //    Console.WriteLine("Bank Accounts: ");
                //    foreach (var bankAccount in bankAccounts)
                //    {
                //        Console.WriteLine($"-- ID: {bankAccount.BankAccountId}" + Environment.NewLine +
                //            $"--- Balance: {bankAccount.Balance:f2}" + Environment.NewLine +
                //            $"--- Bank: {bankAccount.BankName}" + Environment.NewLine +
                //            $"--- SWIFT: {bankAccount.SwiftCode}");
                //    }
                //}

                //if (creditCards.Any())
                //{
                //    Console.WriteLine("Credit Cards: ");
                //    foreach (var creditCard in creditCards)
                //    {
                //        Console.WriteLine($"-- ID: {creditCard.CreditCardId}" + Environment.NewLine +
                //            $"--- Limit: {creditCard.Limit:f2}" + Environment.NewLine +
                //            $"--- Money Owed: {creditCard.MoneyOwed:f2}" + Environment.NewLine +
                //            $"--- Limit Left:: {creditCard.LimitLeft:f2}" + Environment.NewLine +
                //            $"--- Expiration Date: {creditCard.ExpirationDate.ToString("yyyy/MM", CultureInfo.InvariantCulture)}");
                //    }
                //}
                //3та до тук
                PayBills(userId, 100000M); //4та задача
            }
        }

        //4та задача
        private static void PayBills(int userId, decimal billsAmount)
        {
            using (var db = new BillsPaymentSystemContext())
            {
                var user = db.Users
                .Where(u => u.UserId == userId)
                .Select(u => new
                {
                    FullName = $"{u.FirstName} {u.LastName}",
                    CreditCards = u.PaymentMethods
                        .Where(pm => pm.Type == PaymentMethodType.CreditCard)
                        .Select(pm => pm.CreditCard)
                        .OrderBy(c => c.CreditCardId)
                        .ToList(),
                    BankAccounts = u.PaymentMethods
                        .Where(pm => pm.Type == PaymentMethodType.BankAccount)
                        .Select(pm => pm.BankAccount)
                        .OrderBy(b => b.BankAccountId)
                        .ToList()
                })
                .FirstOrDefault();

                var totalMoneyFromBankAccounts = user.BankAccounts.Sum(b => b.Balance);
                var totalMoneyFromCreditCards = user.CreditCards.Sum(c => c.LimitLeft);

                var totalMoney = totalMoneyFromBankAccounts + totalMoneyFromCreditCards;
                if (totalMoney >= billsAmount)
                {
                    foreach (var bankAccount in user.BankAccounts)
                    {
                        var currentBalance = bankAccount.Balance - billsAmount;
                        if (currentBalance <= 0)
                        {
                            billsAmount -= bankAccount.Balance;
                            bankAccount.Withdraw(bankAccount.Balance);
                        }
                        else
                        {
                            bankAccount.Withdraw(billsAmount);
                            billsAmount = 0.0M;
                        }
                    }
                    if (billsAmount >= 0)
                    {
                        foreach (var creditCard in user.CreditCards)
                        {
                            var creditCardCurrentBalance = creditCard.LimitLeft - billsAmount;
                            if (creditCardCurrentBalance <= 0)
                            {
                                billsAmount -= creditCard.LimitLeft;
                                creditCard.Withdraw(creditCard.LimitLeft);
                            }
                            else
                            {
                                creditCard.Withdraw(billsAmount);
                                billsAmount = 0.0M;
                                break;
                            }
                        }
                    }
                    Console.WriteLine($"User: {user.FullName}" + Environment.NewLine +
                        $"has paid all bills!");
                }
                else
                {
                    Console.WriteLine("Insufficient funds!");
                }

            }
        }

        private static void ResetDatabase(BillsPaymentSystemContext context)
        {
            context.Database.EnsureDeleted();

            context.Database.Migrate();

            //InitialSeed(context); //Трябва да се закоментират Withdraw и Deposit методите.
                                    //и да се махнат private access-модеифиерите за 2ра дадача.
        }

        //private static void InitialSeed(BillsPaymentSystemContext context)
        //{
        //    var creditCards = new[]
        //    {
        //        new CreditCard {ExpirationDate = new DateTime(2018,10,10), Limit = 50000, MoneyOwed = 340},
        //        new CreditCard {ExpirationDate = new DateTime(2017,01,11), Limit = 25000, MoneyOwed = 4000},
        //        new CreditCard {ExpirationDate = new DateTime(2020,04,12), Limit = 200000, MoneyOwed = 75000},
        //    };

        //    context.CreditCards.AddRange(creditCards);

        //    var bankAccounts = new[]
        //    {
        //        new BankAccount {Balance = 2500, BankName = "Всички_са_тук",SwiftCode="123hj123sd9a"},
        //        new BankAccount {Balance = 12500, BankName = "SoftUniBank",SwiftCode="9gdf987dj23"},
        //        new BankAccount {Balance = 213, BankName = "Stel4U",SwiftCode="DefNtThivs421"}

        //    };

        //    context.BankAccounts.AddRange(bankAccounts);

        //    var users = new[]
        //    {
        //        new User {Email="No@mail.com",FirstName="No",LastName="Name",Password="nopassword"},
        //        new User {Email="pesho@isking.com",FirstName="Pesho",LastName="IsKing",Password="pesho"},
        //        new User {Email="var@mail.com",FirstName="Maria",LastName="Ignatova",Password="ignatvarmar"},
        //    };

        //    context.Users.AddRange(users);

        //    var paymentMethods = new[]
        //    {
        //        new PaymentMethod {BankAccount = bankAccounts[0],Type = PaymentMethodType.BankAccount,User = users[1]},
        //        new PaymentMethod {CreditCard = creditCards[1],Type = PaymentMethodType.CreditCard,User = users[2]},
        //        new PaymentMethod {CreditCard = creditCards[0],Type = PaymentMethodType.CreditCard,User = users[0]},
        //    };

        //    context.PaymentMethods.AddRange(paymentMethods);

        //    context.SaveChanges();
        //}
    }
}
