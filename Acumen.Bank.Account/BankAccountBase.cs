using System;

namespace Acumen.Bank.Account
{
    public class BankAccountBase
    {
        protected string _ownerName { get; set; }
        protected double _balance { get; set; }

        public BankAccountBase(string ownerName, double balance)
        {
            _ownerName = ownerName;
            _balance = balance;
        }

        public string OwnerName
        {
            get
            {
                return _ownerName;
            }
        }

        public double Balance
        {
            get
            {
                return _balance;
            }
        }

        public virtual void Deposit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Cannot deposit a negative amount");
            }
            _balance += amount;
        }

        public virtual void Transfer(BankAccountBase destinationAccount, double amount)
        {
            if(amount < 0)
            {
                throw new ArgumentException("Cannot transfer a negative amount");
            }
            _balance -= amount;
            destinationAccount.Deposit(amount);
        }
    }
}
