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
        [InlineData(10.0, 0, 10)]
        [InlineData(3.33, 0, 3.33)]

        public void Deposit_Unitest(double expectedValue, double balance, double amount)
        {
            var acutalValue = bankRepository.Deposit(balance, amount);
            Assert.Equal(expectedValue, acutalValue);
        }

        [Theory]
        [InlineData(2900, 3000, 100)]
        [InlineData(500.45, 1000, 499.55)]
        public void Withdraw_Unitest(double expectedValue, double balance, double summa)
        {
            var acutalValue = bankRepository.Withdraw(balance, summa);
            Assert.Equal(expectedValue, acutalValue);
        }

        [Theory]
        [InlineData(true, 3000, 100)]
        [InlineData(false, 1000, 1499.55)]
        [InlineData(false, 1000, -1499.55)]
        public void CheckIfWithdrawIsOk_Unitest(bool expectedValue, double balance, double summa)
        {
            var acutalValue = bankRepository.CheckIfWithdrawIsOk(balance, summa);
            Assert.Equal(expectedValue, acutalValue);
        }

        [Theory]
        [InlineData(true, 3000, 100)]
        [InlineData(true, 1000, 1499.55)]
        [InlineData(false, 1000, -1499.55)]
        [InlineData(false, 1000, 0)]

        public void CheckIfDepositIsOk_Unitest(bool expectedValue, double balance, double summa)
        {
            var acutalValue = bankRepository.CheckIfDepositIsOk(balance, summa);
            Assert.Equal(expectedValue, acutalValue);
        }
               
    }
}
