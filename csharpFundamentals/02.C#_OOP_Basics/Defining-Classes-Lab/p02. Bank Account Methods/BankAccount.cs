public class BankAccount
{
    private int id;
    private decimal balance;

    public BankAccount() { }

    public BankAccount(int id, decimal balance)
        : this()
    {
        this.Balance = balance;
        this.Id = id;
    }
    
    public decimal Balance
    {
        get
        {
            return this.balance;
        }
        set
        {
            this.balance = value;
        }
    }


    public int Id
    {
        get
        {
            return this.id;
        }
        set
        {
            this.id = value;
        }
    }

    public void Deposit(decimal amount)
    {
        this.Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        this.balance -= amount;
    }

    public override string ToString()
    {
        return $"Account {this.Id}, balance {this.Balance}";
    }
}