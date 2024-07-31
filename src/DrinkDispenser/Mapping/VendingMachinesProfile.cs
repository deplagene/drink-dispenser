using AutoMapper;
using DrinkDispenser.Domain.Entities;
using DrinkDispenser.Shared.Dtos;

namespace DrinkDispenser.Mapping;

public class VendingMachinesProfile : Profile
{
    public VendingMachinesProfile()
    {
        CreateMap<VendingMachine, VendingMachineDto>()
            .ForMember(dest => dest.DrinksTitle, opt =>
                opt.MapFrom(src => src.Drinks.Select(x =>
                    x.Name).ToList()));
    }
}
