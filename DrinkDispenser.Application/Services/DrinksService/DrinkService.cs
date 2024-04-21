using DrinkDispenser.Application.Common.Interfaces;
using DrinkDispenser.Domain.Common.Abstractions;
using DrinkDispenser.Domain.Common.Errors.Drinks;
using DrinkDispenser.Domain.Drinks;
using ErrorOr;

namespace DrinkDispenser.Application.Services.DrinksService;

public class DrinkService : IDrinkService
{
    private readonly IDrinkRepository _drinkRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DrinkService(IDrinkRepository drinkRepository, IUnitOfWork unitOfWork)
    {
        _drinkRepository = drinkRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<Created>> CreateDrink(string name, decimal price, string imageUrl, CancellationToken cancellationToken = default)
    {
        var drink = Drink.Create(name, price, imageUrl);

        await _drinkRepository.AddAsync(drink.Value);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Created;

    }

    public async Task<ErrorOr<Deleted>> DeleteDrink(Guid drinkId, CancellationToken cancellationToken = default)
    {
        var drink = await _drinkRepository.GetByIdAsync(drinkId, cancellationToken);

        if (drink is null)
            return Errors.NotFound;

        _drinkRepository.Delete(drink);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Deleted;
    }

    public async Task<ErrorOr<Updated>> UpdateDrink(Guid drinkId, string? name, decimal? price, string? imageUrl, CancellationToken cancellationToken = default)
    {
        var drink = await _drinkRepository.GetByIdAsync(drinkId, cancellationToken);

        if(drink is null)
            return Errors.NotFound;

        if(!string.IsNullOrWhiteSpace(name))
            drink.SetName(name);

        if(price.HasValue)
            drink.SetPrice(price.Value);

        if(!string.IsNullOrWhiteSpace(imageUrl))
            drink.SetImageUrl(imageUrl);

        _drinkRepository.Update(drink);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Updated;
    }
}