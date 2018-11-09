using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HietalasALMBank.Models;
using HietalasALMBank.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HietalasALMBank.Controllers
{
    public class TransferController : Controller
    {
        public IActionResult Transfer()
        {
            TransferViewModel model = new TransferViewModel() { FromAccountNumber = "", ToAccountNumber = "", Amount = 0 };
            return View(model);
        }

        [HttpPost]
        public IActionResult Transfer(TransferViewModel model)
        {
         
            if (ModelState.IsValid)
            {
                if (model.FromAccountNumber == model.ToAccountNumber)
                {
                    TempData["response"] = "Du kan inte överföra mellan samma konto";
                    return View(model);
                }

                BankRepository repo = new BankRepository();
                Account from = repo.GetAccount(model.FromAccountNumber);
                Account to = repo.GetAccount(model.ToAccountNumber);

                if (from == null || to == null)
                {
                    if (from == null)
                    {
                        TempData["fromNull"] = $"Kontonummret {model.FromAccountNumber} kunde inte hittas";
                    }
                    if (to == null)
                    {
                        TempData["toNull"] = $"Kontonummret {model.ToAccountNumber} kunde inte hittas";
                    }
                    
                    return View(model);
                }

                bool transferSuccess = from.Transfer(to, model.Amount);

                if (transferSuccess)
                {
                    TempData["response"] = $"Överföring genomförd! Konto nr:{from.AccountNumber} summa: {from.Balance} Konto nr:{to.AccountNumber} summa: {to.Balance}";
                }
                else
                {
                    TempData["response"] = $"Du kan inte överföra mer pengar än det finns på kontot! Konto nr:{from.AccountNumber} summa: {from.Balance}";
                }

            }
            return View(model);
        }
    }
}