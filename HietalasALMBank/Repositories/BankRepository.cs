using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HietalasALMBank.Repositories
{
    public class BankRepository
    {
        public double Deposit(double balance, double amount)
        {
            return balance += amount;
        }

        public double Withdraw(double balance, double amount)
        {
            return balance -= amount;
        }

        public bool CheckIfWithdrawIsOk(double balance, double amount)
        {
            if (balance >= amount && amount > 0) {
                return true;
            }
            return false;
        }

        public bool CheckIfDepositIsOk(double balance, double amount)
        {
            if (amount > 0)
            {
                return true;
            }
            return false;
        }




    }
}
