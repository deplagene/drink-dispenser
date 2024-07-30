using DrinkDispenser.Domain.Abstractions;
using DrinkDispenser.Domain.Repositories;
using DrinkDispenser.Persistance.Repositories;

using Microsoft.EntityFrameworkCore;

namespace DrinkDispenser.Persistance;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistance(this IServiceCollection services)
    {
        services.AddDbContext<DatabaseContext>(options =>
            options.UseSqlite("Data Source=DrinkDispenser.db"));

        services.AddScoped<IDrinkRepository, DrinkRepository>();
        services.AddScoped<IReadDrinkRepository>(provider => provider.GetRequiredService<IDrinkRepository>());
        services.AddScoped<IWriteDrinkRepository>(provider => provider.GetRequiredService<IDrinkRepository>());

        services.AddScoped<ICoinRepository, CoinRepository>();
        services.AddScoped<IReadCoinRepository>(provider => provider.GetRequiredService<ICoinRepository>());
        services.AddScoped<IWriteCoinRepository>(provider => provider.GetRequiredService<ICoinRepository>());

        services.AddScoped<IVendingMachineRepository, VendingMachineRepository>();
        services.AddScoped<IReadVendingMachineRepository>(provider => provider.GetRequiredService<IVendingMachineRepository>());
        services.AddScoped<IWriteVendingMachineRepository>(provider => provider.GetRequiredService<IVendingMachineRepository>());

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
