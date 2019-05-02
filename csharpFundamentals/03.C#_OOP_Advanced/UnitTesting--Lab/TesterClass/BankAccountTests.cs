using NUnit.Framework;
using System;

namespace UnitTests
{
    [TestFixture]
    public class BankAccountTests
    {
        [Test]
        public void Consstructor_SetsInitialBalance()
        {
            var initialAmount = 10;
            var expectedAmount = 10;

            var bankAccount = new BankAccount(initialAmount);

            Assert.That(bankAccount.Balance, Is.EqualTo(expectedAmount));
        }

        //[Test]
        //public void DepositShouldIncreaseBalance()
        //{
        //    var bankAccount = new BankAccount();
        //    bankAccount.Deposit(10);
        //    //Assert.That(bankAccount.Balance, Is.EqualTo(10));
        //    Assert.AreEqual(10, bankAccount.Balance);
        //}

        ////Прави няколко теста с различни стойности
        //[TestCase(10)]
        //[TestCase(100)]
        //[TestCase(-10)]
        //public void WithdrawThrowsExceptionIfInsuffcieintFunds(int amount)
        //{
        //    var bankAccount = new BankAccount();
        //    Assert.Throws<ArgumentException>(() => bankAccount.Withdraw(amount));
        //}
    }
}