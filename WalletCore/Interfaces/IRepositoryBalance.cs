using System.Collections.Generic;
using System.Threading.Tasks;
using WalletCore.Models;

namespace WalletCore.Interfaces
{
    public interface IRepositoryBalance
    {
        Task<List<BalanceDTO>> GetAllBalances();
        Task<BalanceDTO> GetBalance(int id);
        Task<List<int>> AddTransaction(BalanceDTO balanceDTO);
        Task<decimal> ShowBalance();
    }
}
