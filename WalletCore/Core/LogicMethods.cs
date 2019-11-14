using System;
using System.Collections.Generic;
using WalletCore.Interfaces;
using WalletCore.Models;

namespace WalletCore.Core
{
    public class LogicMethods : ILogicMethods
    {
        public bool AddTransaction(List<BalanceDTO> wallet, string type, decimal deposit)
        {
            var result = true;
            wallet.Add(new BalanceDTO
            {
                Type = type,
                Amount = deposit,
                Date = DateTime.Today
            });

            decimal total = ShowBalance(wallet);
            if (total < 0)
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

            return result;
        }
    }
}
