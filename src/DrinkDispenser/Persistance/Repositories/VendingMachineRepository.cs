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

    public async Task<VendingMachine> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await Set
            .FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken)
            ?? throw new NotFoundException("Автомат не найден.");

    public void Remove(VendingMachine entity) =>
        Set.Remove(entity);
}