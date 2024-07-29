using DrinkDispenser.Domain.Coins;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrinkDispenser.Infrastructure.Persistance.EntityConfigurations;

public class CoinConfiguration : IEntityTypeConfiguration<Coin>
{
    public void Configure(EntityTypeBuilder<Coin> builder)
    {
        builder
            .HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.Nominal)
            .IsRequired();

        builder
            .Property(x => x.Currency)
            .IsRequired();

        builder
            .HasOne(x => x.VendingMachine)
            .WithMany(x => x.Coins)
            .HasForeignKey(x => x.VendingMachineId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);
    }
}
