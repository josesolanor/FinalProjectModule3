using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWallet.Models
{
    public class BalanceDTO
    {
        [Required]
        public string Type { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
