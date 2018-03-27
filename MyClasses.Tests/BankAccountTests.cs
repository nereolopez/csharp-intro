using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

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

        [TestMethod]
        public void IsElegibleForCreditReteurnsTrueTest()
        {
            // Arrange
            const decimal moneyToPut = 30000;
            var account = new BankAccount();

            // Act
            account.PutMoney(moneyToPut);
            bool result = account.IsElegibleForCredit();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsElegibleForCreditReteurnsFalseTest()
        {
            // Arrange
            const decimal moneyToPut = 29999;
            var account = new BankAccount();

            // Act
            account.PutMoney(moneyToPut);
            bool result = account.IsElegibleForCredit();

            // Assert
            Assert.IsFalse(result);
        }

        [DataTestMethod]
        [DataRow(1000, "Bad")]
        [DataRow(5000, "Average")]
        [DataRow(20000, "Good")]
        [DataRow(60000, "Excellent")]
        public void GetFinancialScoreTests(int money, string expected)
        {
            // Arrange
            decimal balance = Convert.ToDecimal(money);

            var mockFinancialService = new Mock<IFinancialService>();
            mockFinancialService.Setup(x => x.GetFinancialScore(balance)).Returns(expected);

            var account = new BankAccount(mockFinancialService.Object);
            account.PutMoney(balance);

            // Act
            string actual = account.GetFinancialScore();

            // Assert
            Assert.AreEqual(actual, expected);

            mockFinancialService.VerifyAll();
        }
    }
}
