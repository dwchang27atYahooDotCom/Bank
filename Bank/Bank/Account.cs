using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class Account
    {
        public enum AccountTypes { CHECKING, CORPORATE_INVESTMENT, INDIVIDUAL_INVESTMENT }

        public AccountTypes accountType { get; set; }

        public decimal balance;

        public Owner owner = new Owner();

        public decimal deposit(decimal amount)
        {
            balance = balance + amount;
            return balance;
        }

        public void transfer(AccountTypes at)
        {
            accountType = at;
        }

        public decimal withdraw(decimal amount)
        {
            if (amount > 1000 && accountType == AccountTypes.INDIVIDUAL_INVESTMENT)
            {
                throw new Exception("can not withdraw more than $1,000 at a time");
            }

            if (balance - amount < 0)
            {
                throw new Exception("not permissible to overdraft an account");
            }

            balance = balance - amount;

            return balance;
        }
    }
}
