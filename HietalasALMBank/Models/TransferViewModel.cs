using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HietalasALMBank.Models
{
    public class TransferViewModel
    {
        public string fromAccountNumber { get; set; }
        public string toAccountNumber { get; set; }
        public double Amount { get; set; }

    }
}
