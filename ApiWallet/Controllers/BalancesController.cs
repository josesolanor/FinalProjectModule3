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
using ApiWallet.Core;

namespace ApiWallet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BalancesController : ControllerBase
    {
        private readonly IRepositoryBalance _repositoryBalance;

        public BalancesController(IRepositoryBalance repositoryBalance)
        {
            _repositoryBalance = repositoryBalance;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BalanceDTO>>> GetBalances()
        {
            var balancesDTO = await _repositoryBalance.GetAllBalances();
            return balancesDTO;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BalanceDTO>> GetBalance(int id)
        {
            var balanceDTO = await _repositoryBalance.GetBalance(id);

            if (balanceDTO is null)
            {
                return NotFound();
            }

            return balanceDTO;
        }

        [HttpPost]
        public async Task<ActionResult<BalanceDTO>> PostBalance(BalanceDTO balanceDTO)
        {

            var result = await _repositoryBalance.AddTransaction(balanceDTO);

            if (result[0].Equals(AddTransaccionResponse.MinorZero))
            {
                return BadRequest("Error, Monto menor a cero");
            }

            if (result[0].Equals(AddTransaccionResponse.ToMuchWithDrawAmount))
            {
                return BadRequest("Error, Monto de retiro mayor al saldo actual");
            }

            return CreatedAtAction("GetBalance", new { id = result[1] }, balanceDTO);

        }

        [Route("Showbalance")]
        public async Task<decimal> ShowBalance()
        {
            var result = await _repositoryBalance.ShowBalance();
            return result;
        }
    }
}
