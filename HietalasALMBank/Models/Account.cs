using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HietalasALMBank.Models
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public double Balance { get; set; }

        public bool Transfer(Account account, double amount)
        {
            if (Balance - amount < 0)
            {
                return false;
            }

            Balance -= amount;
            account.Balance += amount;
            return true;
        }
    }
}
