using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientWallet.Models
{
    public class Wallet
    {
        [Display(Name ="Tipo")]
        public string Type { get; set; }
        [Display(Name = "Monto")]
        public decimal Amount { get; set; }
        [Display(Name = "Fecha")]
        public DateTime Date { get; set; }
    }
}
