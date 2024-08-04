using DrinkDispenser.Domain.Entities;
using DrinkDispenser.Domain.Repositories;
using DrinkDispenser.Errors;
using Microsoft.EntityFrameworkCore;

namespace DrinkDispenser.Persistance.Repositories;

public class VendingMachineRepository(DatabaseContext context) : RepositoryBase<VendingMachine>(context.VendingMachines), IVendingMachineRepository
{
    public async Task AddAsync(VendingMachine entity, CancellationToken cancellationToken = default) =>
        await Set
            .AddAsync(entity, cancellationToken);

    public async Task<IReadOnlyCollection<Drink>> GetAvailableDrinksAsync(
        Guid id,
        int page = 1,
        int pageSize = 10,
        CancellationToken cancellationToken = default) =>
        await Set
            .AsNoTracking()
            .Where(vendingMachine => vendingMachine.Id.Equals(id))
            .SelectMany(vendingMachine => vendingMachine.Drinks)
            .Where(drink => drink.IsAvailable == true)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken)
                ?? throw new NotFoundException("Ничего не найдено");

    public async Task<VendingMachine> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await Set
            .Include(x => x.Drinks)
            .FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken)
            ?? throw new NotFoundException("Автомат не найден.");

    public void Remove(VendingMachine entity) =>
        Set.Remove(entity);
}