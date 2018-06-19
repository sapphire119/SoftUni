public class BankAccount
{
    public int id;
    private decimal balance;

    public int ID
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

    public decimal Balance
    {
        get { return this.balance; }
        set { this.balance = value; }
    }

    void GetMe()
    {
        System.Console.WriteLine("Pesho");
    }
}

