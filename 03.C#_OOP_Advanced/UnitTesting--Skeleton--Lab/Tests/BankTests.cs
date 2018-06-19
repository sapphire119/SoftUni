using Moq;
using NUnit.Framework;

namespace Tests
{
    public class BankTests
    {
        //[Test]
        //public void GetAccountBalance_FormatsToMoney()
        //{
        //    Bank bank = new Bank();
        //    //BankAccount account = new BankAccount(10);
        //    //bank.AccountManager = new AccountManager(account);

        //    //bank.AccountManager = new FakeAccountManager(10);
        //    string expected = $"10.00";
        //    Assert.That(bank.GetAccountBalance(), Is.EqualTo(expected));
        //}

        [Test]
        public void GetAccountBalanace_FormatToMOney_WithMocing()
        {
            var fakeAccountManager = new Mock<IAccountManager>();
            fakeAccountManager.Setup(m => m.GetBalanceInCents())
                .Returns(10);

            var bank = new Bank(fakeAccountManager.Object);
            string expected = "10.00";
            Assert.That(bank.GetAccountBalance(), Is.EqualTo(expected));
        }

        [Test]
        public void GetCurrency_WithMocing()
        {
            var fakeAccountManager = new Mock<IAccountManager>();
            fakeAccountManager.Setup(m => m.Currency)
                .Returns("EUR");

            var bank = new Bank(fakeAccountManager.Object);
            string expected = "EUR";
            Assert.That(bank.GetCurrency(), Is.EqualTo(expected));
        }

        //Вместо фалшиви класове ползваме Moq
        //private class FakeAccountManager : IAccountManager
        //{
        //    private decimal centsToReturn;

        //    public FakeAccountManager(int centsToReturn)
        //    {
        //        this.centsToReturn = centsToReturn;
        //    }

        //    public decimal GetBalanceInCents()
        //    {
        //        return centsToReturn;
        //    }
        //}
    }
}
