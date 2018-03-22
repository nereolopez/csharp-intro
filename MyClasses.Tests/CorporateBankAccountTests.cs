using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyClasses.Tests
{
    [TestClass]
    public class CorporateBankAccountTests
    {
        [TestMethod]
        public void ChargingReducesBalanceTest()
        {
            // Arrange
            decimal initialBalance = 1000m;
            decimal creditLimit = 20000m;
            decimal amount = 15000m;
            decimal expectedFinalBalance = initialBalance - amount;

            var testee = new CorporateBankAccount(initialBalance, creditLimit);

            // Act
            testee.Charge(amount);

            // Assert
            Assert.AreEqual(testee.Balance, expectedFinalBalance);
        }

        [TestMethod]
        public void CannotExceedCreditLimitTest()
        {
            // Arrange
            decimal initialBalance = 1000m;
            decimal creditLimit = 20000m;
            decimal amount = 25000m;

            var testee = new CorporateBankAccount(initialBalance, creditLimit);

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => testee.Charge(amount));
        }

        [TestMethod]
        public void CannotExceedMontlyLimitTest()
        {
            // Arrange
            decimal initialBalance = 1000m;
            decimal creditLimit = 20000m;
            decimal alreadySpent = 14000m;
            decimal amount = 7000m;

            var testee = new CorporateBankAccount(initialBalance, creditLimit);
            testee.SpentInCurrentMoth = alreadySpent;

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() => testee.Charge(amount));
        }
    }
}
