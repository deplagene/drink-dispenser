using DrinkDispenser.Domain.VendingMachines;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrinkDispenser.Infrastructure.Persistance.EntityConfigurations;

public class VendingMachineConfiguration : IEntityTypeConfiguration<VendingMachine>
{
    public void Configure(EntityTypeBuilder<VendingMachine> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder
            .HasMany(x => x.Drinks)
            .WithOne(x => x.VendingMachine)
            .HasForeignKey(x => x.VendingMachineId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);

        builder
            .HasMany(x => x.Coins)
            .WithOne(x => x.VendingMachine)
            .HasForeignKey(x => x.VendingMachineId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);
    }
}
