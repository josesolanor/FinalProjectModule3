﻿using ApiWallet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWallet.Interfaces
{
    public interface ILogicMethods
    {
        decimal ShowBalance(List<BalanceDTO> data);

        bool AddIncomes(List<BalanceDTO> wallet, decimal deposit);
    }
}
