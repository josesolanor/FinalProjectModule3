using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiWallet.Context;
using ApiWallet.Entities;
using ApiWallet.Interfaces;
using ApiWallet.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiWallet.Core
{
    public class RepositoryBalance : IRepositoryBalance
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDBContext _context;
        private readonly ILogicMethods _logicMethods;

        public RepositoryBalance(ApplicationDBContext context,
            IMapper mapper,
            ILogicMethods logicMethods)
        {
            _context = context;
            _mapper = mapper;
            _logicMethods = logicMethods;
        }

        public async Task<List<int>> AddTransaction(BalanceDTO balanceDTO)
        {
            List<int> result = new List<int>();

            if (balanceDTO.Amount <= 0)
            {
                result.Add(AddTransaccionResponse.MinorZero);

                return result;
            }

            var balances = await _context.Balances.ToListAsync();
            var balancesDTO = _mapper.Map<List<BalanceDTO>>(balances);
            var response = _logicMethods.AddTransaction(balancesDTO, balanceDTO.Type, balanceDTO.Amount);

            if (response)
            {
                var balanceEntity = _mapper.Map<Balance>(balanceDTO);
                balanceEntity.Date = DateTime.Now;

                _context.Balances.Add(balanceEntity);
                await _context.SaveChangesAsync();

                result.Add(AddTransaccionResponse.Created);
                result.Add(balanceEntity.Id);

                return result;
            }
            result.Add(AddTransaccionResponse.ToMuchWithDrawAmount);
            return result;
        }

        public async Task<List<BalanceDTO>> GetAllBalances()
        {
            var balances = await _context.Balances.ToListAsync();
            var balancesDTO  = _mapper.Map<List<BalanceDTO>>(balances);
            return balancesDTO;
        }

        public async Task<BalanceDTO> GetBalance(int id)
        {
            var balance = await _context.Balances.FindAsync(id);

            if (balance == null)
            {
                return new BalanceDTO();
            }

            var balanceDTO = _mapper.Map<BalanceDTO>(balance);
            return balanceDTO;
        }

        public async Task<decimal> ShowBalance()
        {
            var balances = await _context.Balances.ToListAsync();
            var balancesDTO = _mapper.Map<List<BalanceDTO>>(balances);

            var result = _logicMethods.ShowBalance(balancesDTO);
            return result;
        }
    }
}
