using ApiWallet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWallet.Core
{
    public interface IRepositoryBalance
    {
        Task<List<BalanceDTO>> GetAllBalances();
        Task<BalanceDTO> GetBalance(int id);
        Task<List<int>> AddTransaction(BalanceDTO balanceDTO);
        Task<decimal> ShowBalance();
    }
}
