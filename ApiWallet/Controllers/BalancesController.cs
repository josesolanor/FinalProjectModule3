using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiWallet.Context;
using ApiWallet.Entities;
using ApiWallet.Models;
using AutoMapper;
using ApiWallet.Interfaces;

namespace ApiWallet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalancesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDBContext _context;
        private readonly ILogicMethods _logicMethods;

        public BalancesController(ApplicationDBContext context,
            IMapper mapper,
            ILogicMethods logicMethods)
        {
            _context = context;
            _mapper = mapper;
            _logicMethods = logicMethods;
        }

        // GET: api/Balances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BalanceDTO>>> GetBalances()
        {
            var balances = await _context.Balances.ToListAsync();
            var balancesDTO = _mapper.Map<List<BalanceDTO>>(balances);
            return balancesDTO;
        }

        // GET: api/Balances/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BalanceDTO>> GetBalance(int id)
        {
            var balance = await _context.Balances.FindAsync(id);

            if (balance == null)
            {
                return NotFound();
            }

            var balanceDTO = _mapper.Map<BalanceDTO>(balance);
            return balanceDTO;
        }

        // POST: api/Balances
        [HttpPost]
        public async Task<ActionResult<BalanceDTO>> PostBalance(BalanceDTO balance)
        {
            var balanceEntity = _mapper.Map<Balance>(balance);
            balanceEntity.Date = DateTime.UtcNow;

            _context.Balances.Add(balanceEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBalance", new { id = balanceEntity.Id }, balance);
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
