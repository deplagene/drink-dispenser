using DrinkDispenser.Application.Common.Interfaces.Base;
using DrinkDispenser.Domain.Drinks;

namespace DrinkDispenser.Application.Common.Interfaces;

public interface IDrinkRepository : IReadDrinkRepository, IWriteDrinkRepository
{
}

public interface IReadDrinkRepository : IReadRepository<Drink, Guid>
{
}

public interface IWriteDrinkRepository : IWriteRepository<Drink>
{
}