using DrinkDispenser.Domain.Common.Abstractions;

namespace DrinkDispenser.Infrastructure.Persistance;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbcontext;

    public UnitOfWork(ApplicationDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return _dbcontext.SaveChangesAsync(cancellationToken);
    }
}