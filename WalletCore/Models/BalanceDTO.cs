using System;
using System.ComponentModel.DataAnnotations;

namespace WalletCore.Models
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
