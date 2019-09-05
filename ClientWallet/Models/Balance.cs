using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientWallet.Models
{
    public class Balance
    {
        [Display(Name = "Tipo")]
        public string Type { get; set; }

        [Display(Name = "Monto")]
        [Required]
        public string Amount { get; set; }

        public decimal RealAmount { get; set; }

    }
}
