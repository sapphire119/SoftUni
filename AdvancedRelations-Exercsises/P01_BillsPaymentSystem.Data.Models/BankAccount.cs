using System;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class BankAccount
    {
        //трябва да се махнат private access модеифиерите за 4та задача 
        //както и Deposit и Withdraw методите
        public int BankAccountId { get; set; }
        public decimal Balance { get; private set; }
        public string BankName { get; set; }
        public string SwiftCode { get; set; }

        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                this.Balance += amount;
            }
            else
            {
                Console.WriteLine("Amount must be positive!");
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount > 0)
            {
                var resultingAmount = this.Balance - amount;
                if (resultingAmount < 0)
                {
                    Console.WriteLine("Insufficient funds!");
                }
                else
                {
                    this.Balance -= amount;
                }
            }
            else
            {
                Console.WriteLine("Amount must be positive!");
            }
        }
    }
}
