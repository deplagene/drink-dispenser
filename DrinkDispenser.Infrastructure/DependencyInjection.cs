using DrinkDispenser.Application.Common;
using DrinkDispenser.Application.Common.Interfaces;
using DrinkDispenser.Domain.Common.Abstractions;
using DrinkDispenser.Infrastructure.BackgroundServices;
using DrinkDispenser.Infrastructure.Persistance;
using DrinkDispenser.Infrastructure.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DrinkDispenser.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddDbContext<ApplicationDbContext>(options => options
                .UseNpgsql(configuration.GetConnectionString("ConnectionStrings:Database"), b => b.MigrationsAssembly("DrinkDispenser.Infrastructure")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IDrinkRepository, DrinkRepository>();
        services.AddScoped<ICoinRepository, CoinRepository>();
        services.AddScoped<IVendingMachineRepository, VendingMachineRepository>();

        services.AddHostedService<MigrationBackgroundServices>();

        return services;
    }
}