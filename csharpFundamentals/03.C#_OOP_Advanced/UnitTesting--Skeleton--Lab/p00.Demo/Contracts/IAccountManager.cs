public interface IAccountManager
{
    decimal GetBalanceInCents();

    string Currency { get; }

}