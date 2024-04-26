using AutoMapper;
using DrinkDispenser.Contracts.Drinks.Responses;
using DrinkDispenser.Contracts.Users;
using DrinkDispenser.Domain.Drinks;
using DrinkDispenser.Domain.User;

namespace DrinkDispenser.WebApi.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Drink, DrinkResponse>();
        CreateMap<User, UserDto>()
            .ConstructUsing(u => new UserDto(u.UserName, u.Email));
    }
}