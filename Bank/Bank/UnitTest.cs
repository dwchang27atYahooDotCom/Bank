using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    class UnitTest
    {
        public static void Main()
        {
            // create bank object
            Bank myBank = new Bank();
            // set name
            myBank.name = "My Chase Bank";

            // create account object
            Account myAccount = new Account();

            // create account owner
            Owner customer = new Owner();
            // set customer name
            customer.name = "JP Morgan";

            // set reference to owner from account object
            myAccount.owner = customer;
            // set account type
            myAccount.accountType = Account.AccountTypes.INDIVIDUAL_INVESTMENT;

            // set account balance
            myAccount.balance = 1001.00m;

            // add account to bank
            myBank.accounts.Add(myAccount);
                      
            Console.WriteLine("Bank name: " + myBank.name);
            Console.WriteLine("Account type: " + myBank.accounts[0].accountType.ToString());
            Console.WriteLine("Beginning balance: $ " + myBank.accounts[0].balance);
            
            // deposit
            decimal myDeposit = myBank.accounts[0].balance + 10.50m;

            Console.WriteLine("After ${0} deposit, balance is $ {1} ", "10.50", Convert.ToString(myBank.accounts[0].deposit(10.50m)));

            try
            {
                Console.WriteLine("Attempting to withdraw {0}... ", "1001.00");
                // withdraw
                myBank.accounts[0].withdraw(1001.00m);
            }
            catch (Exception ex)
            {
                Console.WriteLine(" " + ex.Message);
            }

            Console.WriteLine("Withdraw {0}... ", "1000.00");
            myBank.accounts[0].withdraw(1000.00m);
            Console.WriteLine("Current balance: $ " + myBank.accounts[0].balance);

            try
            {
                Console.WriteLine("Attempting to overdraft {0}... ", "100.00");
                myBank.accounts[0].withdraw(100.00m);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Current balance: $ " + myBank.accounts[0].balance);

            Console.WriteLine("Transfer account type from: " + myBank.accounts[0].accountType.ToString());

            // account transfer
            myBank.accounts[0].transfer(Account.AccountTypes.CHECKING);

            Console.WriteLine(" to account type:  " + myBank.accounts[0].accountType.ToString());

            Console.ReadKey();

        }
    }
}
