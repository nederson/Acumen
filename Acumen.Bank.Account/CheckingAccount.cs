using System;

namespace Acumen.Bank.Account
{
    public class CheckingAccount : BankAccountBase
    {
        public CheckingAccount(string ownerName, double balance) : base(ownerName, balance)
        {
        }

        public void Withdraw(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Cannot withdraw a negative amount");
            }
            _balance -= amount;
        }
    }
}
