using DrinkDispenser.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrinkDispenser.Persistance;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<Coin> Coins { get; set;} = null!;
    public DbSet<Drink> Drinks { get; set;} = null!;

    public DbSet<VendingMachine> VendingMachines { get; set; } = null!;
}