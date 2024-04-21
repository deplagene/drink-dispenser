using DrinkDispenser.Application.Common.Interfaces.Base;
using DrinkDispenser.Domain.VendingMachines;

namespace DrinkDispenser.Application.Common;

public interface IVendingMachineRepository : IReadVendingMachineRepository, IWriteVendingMachineRepository
{
}

public interface IReadVendingMachineRepository : IReadRepository<VendingMachine, Guid>
{
}

public interface IWriteVendingMachineRepository : IWriteRepository<VendingMachine>
{
}