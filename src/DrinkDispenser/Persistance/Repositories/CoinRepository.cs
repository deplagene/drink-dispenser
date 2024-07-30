using DrinkDispenser.Domain.Entities;
using DrinkDispenser.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DrinkDispenser.Persistance.Repositories;

public class CoinRepository(DatabaseContext context) : RepositoryBase<Coin>(context.Coins), ICoinRepository
{
    public async Task AddAsync(Coin entity, CancellationToken cancellationToken = default) =>
        await Set
            .AddAsync(entity, cancellationToken);

    public async Task<Coin> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await Set
            .AsNoTracking()
            .SingleAsync(x => x.Id.Equals(id), cancellationToken);

    public void Remove(Coin entity) =>
        Set.Remove(entity);
}
