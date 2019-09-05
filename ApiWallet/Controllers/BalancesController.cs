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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BalanceDTO>>> GetBalances()
        {
            var balances = await _context.Balances.ToListAsync();
            var balancesDTO = _mapper.Map<List<BalanceDTO>>(balances);
            return balancesDTO;
        }

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

        [HttpPost]
        public async Task<ActionResult<BalanceDTO>> PostBalance(BalanceDTO balanceDTO)
        {

            if (balanceDTO.Amount <= 0)
            {
                return BadRequest("Monto menor a cero");
            }

            var balances = await _context.Balances.ToListAsync();
            var balancesDTO = _mapper.Map<List<BalanceDTO>>(balances);
            var result = _logicMethods.AddTransaction(balancesDTO, balanceDTO.Type, balanceDTO.Amount);

            if (result)
            {
                var balanceEntity = _mapper.Map<Balance>(balanceDTO);
                balanceEntity.Date = DateTime.Now;

                _context.Balances.Add(balanceEntity);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetBalance", new { id = balanceEntity.Id }, balanceDTO);
            }
            return BadRequest("No se pudo realizar la transaccion");            
        }

        [Route("Showbalance")]
        public async Task<decimal> ShowBalance()
        {            
            var balances = await _context.Balances.ToListAsync();
            var balancesDTO = _mapper.Map<List<BalanceDTO>>(balances);

            var result = _logicMethods.ShowBalance(balancesDTO);

            return result;
        }
    }
}
