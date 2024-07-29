using DrinkDispenser.Domain.Abstractions;

namespace DrinkDispenser.Domain.Repositories.Base;

public interface IWriteRepository<TEntity>
    where TEntity : Entity
{
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    void Remove(TEntity entity);
}