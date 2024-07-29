using DrinkDispenser.Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DrinkDispenser.Infrastructure.Persistance.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder
            .Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(x => x.UserName)
            .IsRequired();

        builder
            .Property(x => x.Password)
            .IsRequired();

        builder
            .Property(x => x.Email)
            .IsRequired();

        builder
            .Property(x => x.Roles)
            .IsRequired(false);
    }
}
