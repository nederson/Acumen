using System;

namespace Acumen.Bank.Account
{
    public class SavingsAccount : BankAccountBase
    {
        private double _initialInvestment { get; set; }
        private double _annualInterestRate { get; set; }

        //For savings accounts I assume that when a transfer or deposit is made, the initial investment is set to the updated value
        public SavingsAccount(string ownerName, double balance, double interestRate) : base(ownerName, balance)
        {
            _initialInvestment = balance;
            _annualInterestRate = interestRate;
        }

        public double InitialInvestment
        {
            get
            {
                return _initialInvestment;
            }
        }

        public double AnnualInterestRate
        {
            get
            {
                return _annualInterestRate;
            }
        }

        public override void Deposit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Cannot deposit a negative amount");
            }
            _balance += amount;
            _initialInvestment = _balance;
        }

        public override void Transfer(BankAccountBase destinationAccount, double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Cannot transfer a negative amount");
            }
            _balance -= amount;
            destinationAccount.Deposit(amount);
            _initialInvestment = _balance;
        }
        
        public void ApplyInterest(int timePeriod)
        {
            Deposit(CalculateInterest(timePeriod));
            _initialInvestment = _balance;
        }

        private double CalculateInterest(int timePeriod)
        {
            return _initialInvestment * Math.Pow(1 + _annualInterestRate, timePeriod);
        }
    }
}
