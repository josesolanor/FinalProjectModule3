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
        public bool AddTransaction(List<BalanceDTO> wallet, string type, decimal deposit)
        {
            var result = true;

            var amount =  type.Equals(TransactionType.WithDraw) ? deposit * -1 : deposit;


            wallet.Add(new BalanceDTO
            {
                Type = type,
                Amount = amount,
                Date = DateTime.Today
            });

            if (wallet.Sum(v => v.Amount) < 0)
            {
                result = false;
            }
            return result;
        }

        public decimal ShowBalance(List<BalanceDTO> data)
        {
            decimal result = 0;

            foreach (var item in data)
            {
                if (item.Type.Equals(TransactionType.Deposit))
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
