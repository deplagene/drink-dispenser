using DrinkDispenser.Application.Behavior;
using FluentValidation;

namespace DrinkDispenser.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(opt =>
        {
            opt.AddOpenBehavior(typeof(ValidationBehavior<,>));
            opt.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
        });

        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        return services;
    }
}