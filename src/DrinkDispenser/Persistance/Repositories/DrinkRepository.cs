using DrinkDispenser.Domain.Entities;
using DrinkDispenser.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DrinkDispenser.Persistance.Repositories;

public class DrinkRepository(DatabaseContext context) : RepositoryBase<Drink>(context.Drinks), IDrinkRepository
{
    public async Task AddAsync(Drink entity, CancellationToken cancellationToken = default) =>
        await Set
        .AddAsync(entity, cancellationToken);

    public async Task<Drink> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await Set
        .AsNoTracking()
        .SingleAsync(x => x.Id.Equals(id), cancellationToken);

    public void Remove(Drink entity) =>
        Set.Remove(entity);
}
