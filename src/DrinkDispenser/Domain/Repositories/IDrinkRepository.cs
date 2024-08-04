using DrinkDispenser.Domain.Entities;
using DrinkDispenser.Domain.Repositories.Base;

namespace DrinkDispenser.Domain.Repositories;

public interface IDrinkRepository : IReadDrinkRepository, IWriteDrinkRepository
{
}

public interface IReadDrinkRepository : IReadRepository<Drink, Guid>
{
    Task<IReadOnlyCollection<Drink>> GetAllDrinksAsync(int page = 1, int pageSize = 10, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<Drink>> GetAvailableDrinksAsync(int page = 1, int pageSize = 10, CancellationToken cancellationToken = default);
}

public interface IWriteDrinkRepository : IWriteRepository<Drink>
{
}