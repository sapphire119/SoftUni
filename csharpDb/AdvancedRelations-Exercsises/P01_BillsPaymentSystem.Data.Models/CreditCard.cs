namespace P01_BillsPaymentSystem.Data.Models
{
    using System;

    public class CreditCard
    {
        //трябва да се махнат private access модеифиерите за 4та задача 
        //както и Deposit и Withdraw методите
        public int CreditCardId { get; set; }
        public decimal Limit { get; private set; }
        public decimal MoneyOwed { get; private set; }
        public DateTime ExpirationDate { get; set; }

        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        //Not Included in the DB
        public decimal LimitLeft
        {
            get
            {
                return this.Limit - this.MoneyOwed;
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                var resultingDeposit = this.MoneyOwed -= amount;
                if (resultingDeposit <= 0.0M)
                {
                    this.Limit += amount;
                }
                else
                {
                    this.MoneyOwed -= amount;
                }
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
                var totalMoneyOwed = this.MoneyOwed + amount;
                if (totalMoneyOwed > this.Limit)
                {
                    Console.WriteLine("Insufficient funds!");
                }
                else
                {
                    this.MoneyOwed = totalMoneyOwed;
                }
            }
            else
            {
                Console.WriteLine("Amount must be positive!");
            }
        }
    }
}
