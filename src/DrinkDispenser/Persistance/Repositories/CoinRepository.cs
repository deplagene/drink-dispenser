using DrinkDispenser.Domain.Entities;
using DrinkDispenser.Domain.Repositories;
using DrinkDispenser.Errors;
using Microsoft.EntityFrameworkCore;

namespace DrinkDispenser.Persistance.Repositories;

public class CoinRepository(DatabaseContext context) : RepositoryBase<Coin>(context.Coins), ICoinRepository
{
    public async Task AddAsync(Coin entity, CancellationToken cancellationToken = default) =>
        await Set
            .AddAsync(entity, cancellationToken);

    public async Task<Coin> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await Set
            .FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken)
            ?? throw new NotFoundException("Монета не найдена.");

    public Task<bool> IsCoinExistsInVendingMachineAsync(
        Guid vendingMachineId,
        Guid coinId,
        CancellationToken cancellationToken = default) =>
            Set
            .Where(x => x.VendingMachineId.Equals(vendingMachineId))
            .AnyAsync(x => x.Id.Equals(coinId), cancellationToken);

    public void Remove(Coin entity) =>
        Set.Remove(entity);
}
