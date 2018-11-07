using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HietalasALMBank.Models;

namespace HietalasALMBank.Controllers
{
    public class HomeController : Controller
    {
        private List<Customer> data;

        public HomeController()
        {
            data = Startup.Dummydata;
        }

        public IActionResult Index()
        {
            return View(data);
        }      

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
