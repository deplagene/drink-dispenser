using DrinkDispenser.Domain.Drinks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrinkDispenser.Infrastructure.Persistance.EntityConfigurations;

public class DrinkConfiguration : IEntityTypeConfiguration<Drink>
{
    public void Configure(EntityTypeBuilder<Drink> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.Name)
            .IsRequired();

        builder
            .Property(x => x.Price)
            .IsRequired();

        builder
            .Property(x => x.ImageUrl)
            .IsRequired();

        builder
            .HasOne(x => x.VendingMachine)
            .WithMany(x => x.Drinks)
            .HasForeignKey(x => x.VendingMachineId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}