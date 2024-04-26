using AutoMapper;
using DrinkDispenser.Application.Common;
using DrinkDispenser.Application.Common.Interfaces;
using DrinkDispenser.Contracts.Drinks.Responses;
using DrinkDispenser.Domain.Common.Abstractions;
using DrinkDispenser.Domain.Common.Errors.Drinks;
using DrinkDispenser.Domain.Drinks;
using ErrorOr;

namespace DrinkDispenser.Application.Services.DrinksService;

public class DrinkService : IDrinkService
{
    private readonly IDrinkRepository _drinkRepository;
    private readonly IVendingMachineRepository _vendingMachineRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DrinkService(IDrinkRepository drinkRepository, IUnitOfWork unitOfWork, IMapper mapper, IVendingMachineRepository vendingMachineRepository)
    {
        _drinkRepository = drinkRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _vendingMachineRepository = vendingMachineRepository;
    }

    public async Task<ErrorOr<Created>> CreateDrink(string name, decimal price, string imageUrl, Guid vendingMachineId, CancellationToken cancellationToken = default)
    {
        var drink = Drink.Create(name, price, imageUrl, vendingMachineId);

        var vendingMachine = await _vendingMachineRepository.GetByIdAsync(vendingMachineId, cancellationToken);

        if(vendingMachine is null)
            return Errors.VendingMachineNotFound;

        vendingMachine.IncreaseCountDrinks();

        _vendingMachineRepository.Update(vendingMachine);

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

    public async Task<ErrorOr<List<DrinkResponse>>> GetAllDrinks(CancellationToken cancellationToken = default)
    {
        var drinks = await _drinkRepository.GetAllAsync(cancellationToken);

        if(drinks is null)
            return Errors.DrinksNotFound;

        var drinkResponses = _mapper.Map<List<DrinkResponse>>(drinks);

        return drinkResponses;
    }

    public async Task<ErrorOr<List<DrinkResponse>>> GetAvailableDrinks(CancellationToken cancellationToken = default)
    {
        var drinks = await _drinkRepository.GetAvailableDrinksAsync(cancellationToken);

        if(drinks is null)
            return Errors.DrinksNotFound;

        var drinkResponses = _mapper.Map<List<DrinkResponse>>(drinks);

        return drinkResponses;
    }

    public async Task<ErrorOr<DrinkResponse>> GetDrinkById(Guid drinkId, CancellationToken cancellationToken = default)
    {
        var drink = await  _drinkRepository.GetByIdAsync(drinkId, cancellationToken);

        if(drink is null)
            return Errors.NotFound;

        var drinkResponse = _mapper.Map<DrinkResponse>(drink);

        return drinkResponse;
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

    public async Task<ErrorOr<Updated>> UpdateDrinkAvailability(Guid drinkId, bool? isAvailable, CancellationToken cancellationToken = default)
    {
        var drink = await _drinkRepository.GetByIdAsync(drinkId, cancellationToken);

        if(drink == null)
            return Errors.NotFound;

        if(!isAvailable.HasValue)
            return Errors.AvailabilityCannotBeEmpty;

        drink.SetAvailability(isAvailable.Value);

        _drinkRepository.Update(drink);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Updated;
    }
}