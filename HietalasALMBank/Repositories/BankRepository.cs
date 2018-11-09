using HietalasALMBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HietalasALMBank.Repositories
{
    public class BankRepository
    {
        private List<Customer> customers;

        public BankRepository()
        {
            customers = Startup.Dummydata;
        }

        public double Deposit(Account account, string amount)
        {
            account.Balance += double.Parse(amount);
            return account.Balance;
        }

        public double Withdraw(Account account, string amount)
        {
            account.Balance -= double.Parse(amount);
            return account.Balance;           
        }

        public bool CheckIfWithdrawIsOk(double balance, string amount)
        {
            if (balance >= double.Parse(amount) && double.Parse(amount) > 0) {
                return true;
            }
            return false;
        }

        public bool CheckInputAmount(string amount)
        {
            double checkInputAmount;
            double.TryParse(amount, out checkInputAmount);

            if (checkInputAmount > 0)
            {
                return true;
            }          
            return false;
        }

        public Account GetAccount(string accountNumber)
        {
            foreach (var c in customers)
            {
                Account account = c.AccountList.Find(x => x.AccountNumber == accountNumber);

                if (account != null)
                {
                    return account;
                }
            }

            return null;
        }


    }
}
