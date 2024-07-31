using AutoMapper;
using DrinkDispenser.Domain.Entities;
using DrinkDispenser.Shared.Dtos;

namespace DrinkDispenser.Mapping;

public class CoinsProfile : Profile
{
    public CoinsProfile()
    {
        CreateMap<Coin, CoinDto>()
            .ForMember(dest => dest.Nominal, opt =>
                opt.MapFrom(src => src.Nominal.Value));
    }
}