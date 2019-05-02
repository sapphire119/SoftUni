using System;

public class BankAccount
{
    public BankAccount(int amount)
    {
        this.Balance = amount;
    }

    public decimal Balance { get; set; }

    public void Deposit(int amount)
    {
        this.Balance += amount;
    }

    public void Withdraw(int amount)
    {
        if (this.Balance < amount)
        {
            throw new ArgumentException("Insufficient funds");
        }

        this.Balance -= amount;
    }
}