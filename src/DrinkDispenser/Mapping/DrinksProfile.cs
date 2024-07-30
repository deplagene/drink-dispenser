using AutoMapper;
using DrinkDispenser.Domain.Entities;
using DrinkDispenser.Shared.Dtos;

namespace DrinkDispenser.Mapping;

public class DrinksProfile : Profile
{
    public DrinksProfile()
    {
        CreateMap<Drink, DrinkDto>()
            .ForMember(dest => dest.Price, opt =>
                opt.MapFrom(src => src.Price.Value));
    }
}