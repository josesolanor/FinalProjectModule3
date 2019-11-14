using AutoMapper;
using WalletCore.Entities;
using WalletCore.Models;

namespace WalletCore.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Balance, BalanceDTO>();
        }
    }
}
