using ApiWallet.Interfaces;
using ApiWallet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWallet.Core
{
    public class LogicMethods : ILogicMethods
    {
        public decimal ShowBalance(List<BalanceDTO> data)
        {
            decimal result = 0;

            foreach (var item in data)
            {
                if (item.Type.Equals("Deposit"))
                {
                    result += item.Amount;
                }
                else
                {
                    result -= item.Amount;
                }
            }

            if (result <= 0)
            {
                return 0;
            }

            return result;
        }
    }
}
