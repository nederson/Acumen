using System;
using System.Threading;
using Acumen.Bank.Account;

namespace Acumen.Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Acumen Bank!");
		    Console.WriteLine();

		    CheckingAccount michaelsAccount = new CheckingAccount("Michael", 5000);
		    CheckingAccount gobsAccount = new CheckingAccount("Gob", 2000);

		    Console.WriteLine("Open Accounts:");
		    Console.WriteLine();
		    PrintAccountDetails(michaelsAccount);
		    Console.WriteLine();
		    PrintAccountDetails(gobsAccount);

		    Console.WriteLine();
		    Console.WriteLine("Making transfer of $1000.00...");
            try
            {
                Thread.Sleep(500);
            }
            catch (ThreadInterruptedException)
            {
                return;
            }

		    michaelsAccount.Transfer(gobsAccount, 1000);

		    Console.WriteLine("Updated Account Details:");
		    Console.WriteLine();
		    PrintAccountDetails(michaelsAccount);
		    Console.WriteLine();
		    PrintAccountDetails(gobsAccount);

            Console.ReadLine();


            // sample code for savings account implementation

            // Initialize new savings account with initial balance of $30,000 and 0.89% interest
            SavingsAccount acesSavingsAccount = new SavingsAccount("Ace", 30000, .0089);
            
            SavingsAccount garysSavingsAccount = new SavingsAccount("Gary", 10000, .0056);
            
            acesSavingsAccount.Transfer(garysSavingsAccount, 5000);
            
            // apply 2 years of interest to the savings accounts
            acesSavingsAccount.ApplyInterest(2);
            garysSavingsAccount.ApplyInterest(2);

            Console.WriteLine("Making transfer of $1000.00...");
            try
            {
                Thread.Sleep(500);
            }
            catch (ThreadInterruptedException)
            {
                return;
            }

            acesSavingsAccount.Transfer(garysSavingsAccount, 1000);

            Console.WriteLine("Updated Account Details:");
            Console.WriteLine();
            PrintAccountDetails(acesSavingsAccount);
            Console.WriteLine();
            PrintAccountDetails(garysSavingsAccount);

            Console.ReadLine();
        }

        private static void PrintAccountDetails(BankAccountBase account) {
		    Console.WriteLine("Account for {0}:\r\n", account.OwnerName);
            Console.WriteLine("Balance: {0:C2}\r\n", account.Balance);
	    }
    }
}
