using System;

namespace MyClasses
{
    public class CorporateBankAccount : BankAccount
    {
        private decimal creditLimit;

        public decimal SpentInCurrentMoth { get; set; }

        public CorporateBankAccount(decimal initialBalance, decimal creditLimit)
            : base(initialBalance)
        {
            this.creditLimit = creditLimit;
        }

        public void Charge(decimal amount)
        {
            if (amount > creditLimit || amount + this.SpentInCurrentMoth > this.creditLimit)
                throw new InvalidOperationException();

            this.balance -= amount;

        }
    }
}
