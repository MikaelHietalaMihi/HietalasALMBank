using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HietalasALMBank.Models
{
    public class TransferViewModel
    {

        [Required(ErrorMessage = "Ett kontonummer är obligatoriskt")]
        public string FromAccountNumber { get; set; }
        [Required(ErrorMessage = "Ett kontonummer är obligatoriskt")]
        public string ToAccountNumber { get; set; }
        [Range(1, double.MaxValue)]
        public double Amount { get; set; }

    }
}
