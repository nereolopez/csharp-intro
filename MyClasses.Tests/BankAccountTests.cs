using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyClasses.Tests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void EmptyInitializedAccountTest()
        {
            var testee = new BankAccount();
            Assert.AreEqual(testee.Balance, 0);
        }

        [TestMethod]
        public void InitialBalanceOnAccountCreationTest()
        {
            decimal initialBalance = 1000m;
            var testee = new BankAccount(initialBalance);
            Assert.AreEqual(testee.Balance, initialBalance);
        }

        [TestMethod]
        public void CanWithdrawTest()
        {
            decimal initialBalance = 1000m;
            decimal amount = 1500m;
            decimal expectedFinalBalance = initialBalance - amount;

            var testee = new BankAccount(initialBalance);
            testee.Withdraw(amount);
            Assert.AreEqual(testee.Balance, expectedFinalBalance);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CannotWithdrawMoreThanOperationLimitOnBankAccount()
        {
            decimal initialBalance = 3000m;
            decimal amount = 2500m;
            var testee = new BankAccount(initialBalance);
            testee.Withdraw(amount);
        }

        [TestMethod]
        public void BalanceIncreasedWhenPuttingMoneyTest()
        {
            decimal initialBalance = 2000m;
            decimal amount = 1500m;
            decimal expectedAmount = initialBalance + amount;
            var testee = new BankAccount(initialBalance);
            testee.PutMoney(amount);
            Assert.AreEqual(testee.Balance, expectedAmount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CannotPutNegativeAmountIntoAccountTest()
        {
            decimal initialBalance = 2000m;
            decimal amount = -500;

            var testee = new BankAccount(initialBalance);
            testee.PutMoney(amount);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CannotPutZeroIntoAccountTest()
        {
            decimal initialBalance = 2000m;
            decimal amount = 0;

            var testee = new BankAccount(initialBalance);
            testee.PutMoney(amount);
        }
    }
}
