using DrinkDispenser.Domain.Entities;
using DrinkDispenser.Domain.Repositories.Base;

namespace DrinkDispenser.Domain.Repositories;

public interface ICoinRepository : IReadCoinRepository, IWriteCoinRepository
{
}

public interface IReadCoinRepository : IReadRepository<Coin, Guid>
{
}

public interface IWriteCoinRepository : IWriteRepository<Coin>
{
}
