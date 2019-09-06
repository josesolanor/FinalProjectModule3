using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWallet.Core;
using ApiWallet.Entities;
using ApiWallet.Models;

namespace TestClient.Mocks
{
    public class ShowBalanceMock : IRepositoryBalance
    {
        public Task<List<int>> AddTransaction(BalanceDTO balanceDTO)
        {
            List<int> data = new List<int>
            {
                0,
                1
            };

            return Task.FromResult(data);
        }

        public Task<List<BalanceDTO>> GetAllBalances()
        {
            throw new NotImplementedException();
        }

        public Task<BalanceDTO> GetBalance(int id)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> ShowBalance()
        {
            decimal data = 100;
            return Task.FromResult(data);
        }
    }
}
