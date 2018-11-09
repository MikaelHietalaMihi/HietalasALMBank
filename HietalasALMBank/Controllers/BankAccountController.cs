using System;
using System.Collections.Generic;
using HietalasALMBank.Models;
using HietalasALMBank.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HietalasALMBank.Controllers
{
    public class BankAccountController : Controller
    {
        private List<Customer> customers;
        private BankRepository bankRepo;

        public BankAccountController()
        {
            customers = Startup.Dummydata;
            bankRepo = new BankRepository();
        }

        public IActionResult WithdrawAndDeposit(string accountNumber = null, double amount = 0)
        {
            WithdrawDepositViewModel model = new WithdrawDepositViewModel() { AccountNumber = accountNumber, Amount = amount };
            return View(model);
        }

        public IActionResult Deposit(string accountNumber, string amount)
        {
            string errorMessage = CheckInputs(accountNumber, amount);

            if (errorMessage == null)
            {
                Account account = bankRepo.GetAccount(accountNumber);
                var newBalance = bankRepo.Deposit(account, amount);
                TempData["responseSuccess"] = $"Konto: {accountNumber}, Nytt saldo: { newBalance }";
                return RedirectToAction("WithdrawAndDeposit", new { accountNumber });
            }
            else
            {
                TempData["responseFailed"] = errorMessage;
                return RedirectToAction("WithdrawAndDeposit", new { accountNumber });
            }
        }

        public IActionResult Withdraw(string accountNumber, string amount)
        {
            string errorMessage = CheckInputs(accountNumber, amount);
                                 
            if (errorMessage == null)
            {
                Account account = bankRepo.GetAccount(accountNumber);

                if (bankRepo.CheckIfWithdrawIsOk(account.Balance, amount) == false)
                {
                    errorMessage = $"Saldo måste vara högre än summa. Aktuellt saldo: {account.Balance}";
                }
                else
                {
                    var newBalance = bankRepo.Withdraw(account, amount);
                    TempData["responseSuccess"] = $"Konto: {accountNumber}, Nytt saldo: { newBalance }";
                    return RedirectToAction("WithdrawAndDeposit", new { accountNumber });
                }
            }
            TempData["responseFailed"] = errorMessage;
            return RedirectToAction("WithdrawAndDeposit", new { accountNumber });
        }


        public string CheckInputs(string accountNumber, string amount)
        {
            string errorMessage = null;

            if (bankRepo.CheckInputAmount(amount) == false)
            {
                errorMessage = $"Felaktigt inmatning {amount}: Belopp måste vara över 0 och siffror";
            }

            Account account = bankRepo.GetAccount(accountNumber);

            if (account == null)
            {
                errorMessage = $"Hittar inget konto med kontonummer: {accountNumber}";
            }

            return errorMessage;
        }
    }
}