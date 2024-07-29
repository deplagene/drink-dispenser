using DrinkDispenser.Domain.Coins;
using DrinkDispenser.Domain.Drinks;
using DrinkDispenser.Domain.User;
using DrinkDispenser.Domain.VendingMachines;
using DrinkDispenser.Infrastructure.Persistance.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DrinkDispenser.Infrastructure.Persistance;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
        : base(dbContextOptions)
    {
    }

    public DbSet<Drink> Drinks { get; set; }

    public DbSet<VendingMachine> VendingMachines { get; set; }

    public DbSet<Coin> Coins { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new DrinkConfiguration());
        modelBuilder.ApplyConfiguration(new VendingMachineConfiguration());
        modelBuilder.ApplyConfiguration(new CoinConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseNpgsql();
        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
