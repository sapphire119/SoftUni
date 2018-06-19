public class Bank
{
    public IAccountManager AccountManager { get; set; }

    public Bank(IAccountManager accountManager)
    {
        this.AccountManager = accountManager;
    }

    public string GetCurrency()
    {
        return this.AccountManager.Currency;
    }

    public string GetAccountBalance()
    {
        return $"{this.AccountManager.GetBalanceInCents():F2}";
    }
}