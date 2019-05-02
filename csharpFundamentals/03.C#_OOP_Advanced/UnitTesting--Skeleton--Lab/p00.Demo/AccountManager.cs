public class AccountManager : IAccountManager
{
    public BankAccount Account { get; private set; }

    public string Currency => "EUR";

    public AccountManager(BankAccount bankAccount)
    {
        this.Account = bankAccount;
    }

    public decimal GetBalanceInCents()
    {
        return Account.Balance;
    }
}