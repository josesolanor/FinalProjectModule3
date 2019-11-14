using System.Collections.Generic;
using WalletCore.Models;

namespace WalletCore.Interfaces
{
    public interface ILogicMethods
    {
        decimal ShowBalance(List<BalanceDTO> data);
        bool AddTransaction(List<BalanceDTO> wallet, string type, decimal deposit);
    }
}
