using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HietalasALMBank.Controllers
{
    public class TransferController : Controller
    {
        public IActionResult Transfer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Transfer()
        {
            return View();
        }
    }
}