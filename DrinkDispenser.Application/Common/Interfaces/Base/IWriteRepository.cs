using DrinkDispenser.Domain.Common.Models;

namespace DrinkDispenser.Application.Common.Interfaces.Base;

public interface IWriteRepository<TEntity>
    where TEntity : Entity
{
    Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    void Update(TEntity entity);

    void Delete(TEntity entity);
}