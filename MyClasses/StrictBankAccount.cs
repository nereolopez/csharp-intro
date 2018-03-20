using System;

namespace MyClasses
{
    public class StrictBankAccount : BankAccount
    {
        public StrictBankAccount(decimal initialBalance = 0)
            : base(initialBalance)
        {
        }

        public override void Withdraw(decimal amount)
        {
            if (amount > base.Balance)
                throw new ArgumentException("Cannot withdraw more than available.");

            base.Withdraw(amount);
        }
    }
}
