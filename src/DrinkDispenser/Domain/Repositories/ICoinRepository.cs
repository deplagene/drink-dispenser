using DrinkDispenser.Domain.Entities;
using DrinkDispenser.Domain.Repositories.Base;

namespace DrinkDispenser.Domain.Repositories;

public interface ICoinRepository : IReadCoinRepository, IWriteCoinRepository
{
}

public interface IReadCoinRepository : IReadRepository<Coin, Guid>
{
    Task<bool> IsCoinExistsInVendingMachineAsync(Guid vendingMachineId, Guid coinId, CancellationToken cancellationToken = default);
}

public interface IWriteCoinRepository : IWriteRepository<Coin>
{
}
