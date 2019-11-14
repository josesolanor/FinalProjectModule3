﻿using ApiWallet.Models;
using System.Collections.Generic;

namespace ApiWallet.Interfaces
{
    public interface ILogicMethods
    {
        decimal ShowBalance(List<BalanceDTO> data);
        bool AddTransaction(List<BalanceDTO> wallet, string type, decimal deposit);
    }
}
