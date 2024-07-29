using DrinkDispenser.Application.Common.Interfaces.Base;
using DrinkDispenser.Domain.Coins;

namespace DrinkDispenser.Application.Common.Interfaces;

public interface ICoinRepository : IReadCoinRepository, IWiteCoinRepository
{
}

public interface IReadCoinRepository : IReadRepository<Coin, Guid>
{
}

public interface IWiteCoinRepository : IWriteRepository<Coin>
{
}