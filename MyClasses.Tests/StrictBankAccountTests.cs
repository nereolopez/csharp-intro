using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyClasses.Tests
{
    [TestClass]
    public class StrictBankAccountTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CannotWithdrawMoreThanAvailableOnStrictAccountTest()
        {
            decimal initialBalance = 1000m;
            decimal amount = 1500m;

            var testee = new StrictBankAccount(initialBalance);
            testee.Withdraw(amount);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CannotWithdrawMoreThanOperationLimitOnStrictAccountTest()
        {
            decimal initialBalance = 3000m;
            decimal amount = 2001m;
            var testee = new StrictBankAccount(initialBalance);
            testee.Withdraw(amount);
        }
    }
}
