using DrinkDispenser.Domain.Entities;
using DrinkDispenser.Domain.Repositories.Base;

namespace DrinkDispenser.Domain.Repositories;

public interface IDrinkRepository : IReadDrinkRepository, IWriteDrinkRepository
{
}

public interface IReadDrinkRepository : IReadRepository<Drink, Guid>
{
}

public interface IWriteDrinkRepository : IWriteRepository<Drink>
{
}