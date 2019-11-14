using ApiWallet.Entities;
using ApiWallet.Models;
using AutoMapper;

namespace ApiWallet.Mapper
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Balance, BalanceDTO>();
        }
    }
}
