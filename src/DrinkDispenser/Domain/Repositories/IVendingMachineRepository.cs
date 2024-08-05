using DrinkDispenser.Domain.Entities;
using DrinkDispenser.Domain.Repositories.Base;

namespace DrinkDispenser.Domain.Repositories;

public interface IVendingMachineRepository : IReadVendingMachineRepository, IWriteVendingMachineRepository
{
}

public interface IWriteVendingMachineRepository : IWriteRepository<VendingMachine>
{
}

public interface IReadVendingMachineRepository : IReadRepository<VendingMachine, Guid>
{
    Task<IReadOnlyCollection<Drink>> GetAvailableDrinksAsync(Guid id, int page = 1, int pageSize = 10, CancellationToken cancellationToken = default);
}