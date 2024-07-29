using DrinkDispenser.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace DrinkDispenser.Persistance.Repositories;

public abstract class RepositoryBase<TEntity>(DbSet<TEntity> set)
    where TEntity : Entity
{
    public DbSet<TEntity> Set => set;
}