using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWallet.Entities
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
