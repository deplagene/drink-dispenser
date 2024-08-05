using DrinkDispenser.Domain.Entities;
using DrinkDispenser.Domain.Repositories;
using DrinkDispenser.Errors;
using Microsoft.EntityFrameworkCore;

namespace DrinkDispenser.Persistance.Repositories;

public class DrinkRepository(DatabaseContext context) : RepositoryBase<Drink>(context.Drinks), IDrinkRepository
{
    public async Task AddAsync(Drink entity, CancellationToken cancellationToken = default) =>
        await Set
        .AddAsync(entity, cancellationToken);

    public async Task<IReadOnlyCollection<Drink>> GetAllDrinksAsync(
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default) =>
        await Set
            .AsNoTracking()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken)
                ?? throw new NotFoundException("Ничего не найдено");
    public async Task<IReadOnlyCollection<Drink>> GetAvailableDrinksAsync(
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default) =>
        await Set
            .AsNoTracking()
            .Where(drink => drink.IsAvailable == true)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken)
                ?? throw new NotFoundException("Ничего не найдено");

    public async Task<Drink> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await Set
        .FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken)
            ?? throw new NotFoundException("Напиток не найден.");

    public async Task<bool> IsDrinkExistsInVendingMachineAsync(
        Guid vendingMachineId,
        Guid drinkId,
        CancellationToken cancellationToken = default) =>
            await Set
                .Where(x => x.VendingMachineId.Equals(vendingMachineId))
                .AnyAsync(x => x.Id.Equals(drinkId), cancellationToken);

    public void Remove(Drink entity) =>
        Set.Remove(entity);
}
