
using DrinkDispenser.Domain.Abstractions;

namespace DrinkDispenser.Persistance;

public class UnitOfWork(DatabaseContext context) : IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => context.SaveChangesAsync(cancellationToken);
}
