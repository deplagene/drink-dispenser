using DrinkDispenser.Domain.Entities;
using DrinkDispenser.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DrinkDispenser.Persistance.Repositories;

public class VendingMachineRepository(DatabaseContext context) : RepositoryBase<VendingMachine>(context.VendingMachines), IVendingMachineRepository
{
    public async Task AddAsync(VendingMachine entity, CancellationToken cancellationToken = default) =>
        await Set
            .AddAsync(entity, cancellationToken);

    public async Task<VendingMachine> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await Set
            .AsNoTracking()
            .SingleAsync(x => x.Id.Equals(id), cancellationToken);

    public void Remove(VendingMachine entity) =>
        Set.Remove(entity);
}