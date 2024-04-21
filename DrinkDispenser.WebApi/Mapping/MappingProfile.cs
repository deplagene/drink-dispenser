using AutoMapper;
using DrinkDispenser.Contracts.Drinks.Responses;
using DrinkDispenser.Domain.Drinks;

namespace DrinkDispenser.WebApi.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Drink, DrinkResponse>();
    }
}