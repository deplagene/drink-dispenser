using DrinkDispenser.Application.Common.Interfaces.Base;
using DrinkDispenser.Domain.Drinks;

namespace DrinkDispenser.Application.Common.Interfaces;

public interface IDrinkRepository : IReadDrinkRepository, IWriteDrinkRepository
{
}

public interface IReadDrinkRepository : IReadRepository<Drink, Guid>
{
    Task<IReadOnlyCollection<Drink>> GetAvailableDrinksAsync(CancellationToken cancellationToken = default);
}

public interface IWriteDrinkRepository : IWriteRepository<Drink>
{
}