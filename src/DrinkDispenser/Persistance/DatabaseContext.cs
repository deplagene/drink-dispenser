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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Coin>(coin =>
        {
            coin.HasKey(x => x.Id);

            coin.ComplexProperty(x => x.Nominal);

            coin.HasOne(x => x.VendingMachine)
                .WithMany(x => x.Coins);
        });

        modelBuilder.Entity<Drink>(drink =>
        {
            drink.HasKey(x => x.Id);

            drink.ComplexProperty(x => x.Price);

            drink.HasOne(x => x.VendingMachine)
                .WithMany(x => x.Drinks);
        });

        modelBuilder.Entity<VendingMachine>(vendingMachine =>
        {
            vendingMachine.HasKey(x => x.Id);

            vendingMachine.HasMany(v => v.Coins)
                .WithOne(c => c.VendingMachine);

            vendingMachine.HasMany(v => v.Drinks)
                .WithOne(d => d.VendingMachine);
        });

        base.OnModelCreating(modelBuilder);
    }
}