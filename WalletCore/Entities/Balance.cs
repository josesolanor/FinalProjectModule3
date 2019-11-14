using System;
using System.ComponentModel.DataAnnotations;


namespace WalletCore.Entities
{
    public class Balance
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
