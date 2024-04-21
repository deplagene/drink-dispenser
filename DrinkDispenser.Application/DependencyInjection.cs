using DrinkDispenser.Application.Services.CoinsService;
using DrinkDispenser.Application.Services.DrinksService;
using DrinkDispenser.Application.Services.VendingMachinesService;
using Microsoft.Extensions.DependencyInjection;

namespace DrinkDispenser.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IDrinkService, DrinkService>();
        services.AddScoped<IVendingMachineService, VendingMachineService>();
        services.AddScoped<ICoinService, CoinService>();
        return services;
    }
}