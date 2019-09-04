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
        [Range(1, int.MaxValue, ErrorMessage = "Monto no puede ser cero")]
        public decimal Amount { get; set; }
    }
}
