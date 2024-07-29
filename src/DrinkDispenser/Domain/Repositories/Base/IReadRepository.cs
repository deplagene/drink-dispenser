using DrinkDispenser.Domain.Abstractions;

namespace DrinkDispenser.Domain.Repositories.Base;

public interface IReadRepository<TEntity, TKey>
    where TEntity : Entity
    where TKey : IEquatable<TKey>
{
    Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);
}