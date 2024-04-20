using DrinkDispenser.Application.Common.Interfaces;
using DrinkDispenser.Domain.Common.Abstractions;
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
                .UseNpgsql(configuration.GetConnectionString("Database")));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IDrinkRepository, DrinkRepository>();
        services.AddScoped<ICoinRepository, CoinRepository>();

        return services;
    }
}