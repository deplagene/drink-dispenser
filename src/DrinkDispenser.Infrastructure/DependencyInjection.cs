using DrinkDispenser.Application.Common;
using DrinkDispenser.Application.Common.Authentication;
using DrinkDispenser.Application.Common.Interfaces;
using DrinkDispenser.Domain.Common.Abstractions;
using DrinkDispenser.Infrastructure.Authentication;
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
        // services
        //     .AddDbContext<ApplicationDbContext>(options => options
        //         .UseNpgsql(configuration.GetConnectionString("Database"), b => b.MigrationsAssembly("DrinkDispenser.Infrastructure")));

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite("DataSource=DrinkDispenser.db"));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IDrinkRepository, DrinkRepository>();
        services.AddScoped<IReadDrinkRepository>(provider => provider.GetRequiredService<IDrinkRepository>());
        services.AddScoped<IWriteDrinkRepository>(provider => provider.GetRequiredService<IDrinkRepository>());
        services.AddScoped<ICoinRepository, CoinRepository>();
        services.AddScoped<IReadCoinRepository>(provider => provider.GetRequiredService<ICoinRepository>());
        services.AddScoped<IVendingMachineRepository, VendingMachineRepository>();
        services.AddScoped<IReadVendingMachineRepository>(provider => provider.GetRequiredService<IVendingMachineRepository>());
        services.AddScoped<IWriteVendingMachineRepository>(provider => provider.GetRequiredService<IVendingMachineRepository>());
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IReadUserRepository>(provider => provider.GetRequiredService<IUserRepository>());
        services.AddScoped<IWriteUserRepository>(provider => provider.GetRequiredService<IUserRepository>());
        services.AddScoped<IPasswordHasher, passwordHasher>();
        services.AddScoped<IJwtProvider, JwtProvider>();
        services.Configure<JwtOptions>(configuration.GetSection(JwtOptions.SectionName));

        services.AddHostedService<MigrationBackgroundServices>();

        return services;
    }
}