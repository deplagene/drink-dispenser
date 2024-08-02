using DrinkDispenser.Application;
using DrinkDispenser.GlobalErrorHandling;
using DrinkDispenser.Mapping;
using DrinkDispenser.Persistance;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    // configure services(Dependency Injection)

    builder.Services
        .AddExceptionHandler<BadRequestExceptionHandler>()
        .AddExceptionHandler<NotFoundExceptionHandler>()
        .AddExceptionHandler<GlobalExceptionHandler>()
        .AddProblemDetails();

    builder.Services
        .AddControllers();

    builder.Services
        .AddPersistance()
        .AddApplication();

    builder.Services
        .AddAutoMapper(opt =>
        {
            opt.AddProfile<DrinksProfile>();
            opt.AddProfile<VendingMachinesProfile>();
            opt.AddProfile<CoinsProfile>();
        });

}

var app = builder.Build();
{
    // configure pipeline

    app.MapControllers();
    app.UseRouting();
    app.UseExceptionHandler();
}

await app.Services
    .CreateScope()
    .ServiceProvider
    .GetRequiredService<DatabaseContext>()
    .Database
    .MigrateAsync();

app.Run();
