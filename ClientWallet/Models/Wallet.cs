using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientWallet.Models
{
    public class Wallet
    {
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
