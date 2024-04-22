using DrinkDispenser.Contracts.Drinks.Responses;
using DrinkDispenser.Domain.Drinks;
using ErrorOr;

namespace DrinkDispenser.Application.Services.DrinksService;

public interface IDrinkService
{
    Task<ErrorOr<Created>> CreateDrink(string name, decimal price, string imageUrl, CancellationToken cancellationToken = default!);

    Task<ErrorOr<Deleted>> DeleteDrink(Guid drinkId, CancellationToken cancellationToken = default!);

    Task<ErrorOr<Updated>> UpdateDrink(Guid drinkId, string? name, decimal? price, string? imageUrl, CancellationToken cancellationToken = default!);

    Task<ErrorOr<List<DrinkResponse>>> GetAllDrinks(CancellationToken cancellationToken = default!);

    Task<ErrorOr<DrinkResponse>> GetDrinkById(Guid drinkId, CancellationToken cancellationToken = default!);

    Task<ErrorOr<List<DrinkResponse>>> GetAvailableDrinks(CancellationToken cancellationToken = default!);
}