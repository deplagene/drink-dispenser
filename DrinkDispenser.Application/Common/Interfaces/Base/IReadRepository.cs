using DrinkDispenser.Domain.Common.Models;

namespace DrinkDispenser.Application.Common.Interfaces.Base;

public interface IReadRepository<TEntity, TKey>
    where TEntity : Entity
    where TKey : IEquatable<TKey>
{
    Task<TEntity?> GetByIdAsync(TKey id, CancellationToken cancellationToken = default);
}