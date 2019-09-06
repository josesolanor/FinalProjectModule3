using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWallet.Models
{
    public class TransactionType
    {
        public static string WithDraw = "WithDraw";
        public static string Deposit = "Deposit";
    }

    public class AddTransaccionResponse
    {
        public static int Created = 0;
        public static int MinorZero = 1;
        public static int ToMuchWithDrawAmount = 2;
    }
}
