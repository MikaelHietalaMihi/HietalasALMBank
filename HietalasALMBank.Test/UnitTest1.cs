using HietalasALMBank.Models;
using HietalasALMBank.Repositories;
using System;
using System.Collections.Generic;
using Xunit;

namespace HietalasALMBank.Test
{
    public class UnitTest1
    {

        private List<Customer> data = Startup.Dummydata;
        private BankRepository bankRepository = new BankRepository();


        [Theory]
        [InlineData(false, "12")]
        [InlineData(true, "2")]

        public void GetAccount_Test(bool expectedValue, string accountNumber)
        {
            var account = bankRepository.GetAccount(accountNumber);
            var actualValue = true;
            
            if (account == null)
            {
                actualValue = false;
            }

            Assert.Equal(expectedValue, actualValue);
        }


        [Theory]
        [InlineData(20.0, "1", 10)]
        [InlineData(30.5, "2", 10.5)]

        public void Deposit_Test(double expectedValue, string accountNumber, double amount)
        {
            var account = bankRepository.GetAccount(accountNumber);                       
            var acutalValue = bankRepository.Deposit(account, amount.ToString());

            Assert.Equal(expectedValue, acutalValue);
        }

        [Theory]
        [InlineData(10, "3", 20)]
        [InlineData(29.5, "4", 10.5)]
        public void Withdraw_Test(double expectedValue, string accountNumber, double amount)
        {
            var account = bankRepository.GetAccount(accountNumber);
            var acutalValue = bankRepository.Withdraw(account, amount.ToString());

            Assert.Equal(expectedValue, acutalValue);
        }

        [Theory]
        [InlineData(true, 3000, 100)]
        [InlineData(false, 1000, 1499.55)]
        [InlineData(false, 1000, -1499.55)]
        public void CheckIfWithdrawIsOk_Test(bool expectedValue, double balance, double amount)
        {
            var acutalValue = bankRepository.CheckIfWithdrawIsOk(balance, amount.ToString());
            Assert.Equal(expectedValue, acutalValue);
        }

        [Theory]
        [InlineData(true, "3000")]
        [InlineData(false, "-3000")]
        [InlineData(false, "adsada")]
        [InlineData(false, "")]        
        [InlineData(false, "1000.5")]
        [InlineData(true, "1000,5")]
        [InlineData(false, "-1000,5")]

        public void CheckInputAmount_Test(bool expectedValue, string amount)
        {
            var acutalValue = bankRepository.CheckInputAmount(amount);
            Assert.Equal(expectedValue, acutalValue);
        }

        [Fact]
        public void Transfer()
        {
            Account account = new Account() { AccountNumber = "1", Balance = 100 };
            Account to = new Account() { AccountNumber = "2", Balance = 200 };

            account.Transfer(to, 50);

            double expected = 50;
            double actual = account.Balance;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(false, 200)]
        [InlineData(true, 50)]
        public void Try_To_Move_To_Much_Money(bool expected, double amount)
        {
            Account account = new Account() { AccountNumber = "1", Balance = 100 };
            Account to = new Account() { AccountNumber = "2", Balance = 200 };           

            bool actual = account.Transfer(to, amount);

            Assert.Equal(expected, actual);
        }
               
    }
}
