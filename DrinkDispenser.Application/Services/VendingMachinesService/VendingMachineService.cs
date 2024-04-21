using DrinkDispenser.Application.Common;
using DrinkDispenser.Application.Common.Interfaces;
using DrinkDispenser.Domain.Coins;
using DrinkDispenser.Domain.Common.Abstractions;
using DrinkDispenser.Domain.Common.Errors.VendingMachines;
using DrinkDispenser.Domain.Drinks;
using DrinkDispenser.Domain.VendingMachines;
using ErrorOr;

namespace DrinkDispenser.Application.Services.VendingMachinesService;

public class VendingMachineService : IVendingMachineService
{
    private readonly IVendingMachineRepository _vendingMachineRepository;
    private readonly IDrinkRepository _drinkRepository;
    private readonly IUnitOfWork _unitOfWork;

    public VendingMachineService(IVendingMachineRepository vendingMachineRepository, IUnitOfWork unitOfWork, IDrinkRepository drinkRepository)
    {
        _vendingMachineRepository = vendingMachineRepository;
        _unitOfWork = unitOfWork;
        _drinkRepository = drinkRepository;
    }

    public async Task<ErrorOr<Success>> AddCoinToVendingMachine(Guid vendingMachineId, Coin coin, CancellationToken cancellationToken = default)
    {
        var vendingMachine = await _vendingMachineRepository.GetByIdAsync(vendingMachineId, cancellationToken);

        if(vendingMachine is null)
            return Errors.VendingMachineNotFound;

        var validateCoin = Coin.IsValid(coin);

        if(!validateCoin)
            return Errors.InvalidCoin;

        vendingMachine.UpdateBalance(coin.Nominal);

        _vendingMachineRepository.Update(vendingMachine);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }

    public async Task AddDrinksToVendingMachine(Guid vendingMachineId, List<Drink> drinks, CancellationToken cancellationToken = default)
    {
        var vendingMachine = await _vendingMachineRepository.GetByIdAsync(vendingMachineId, cancellationToken);
    }

    public async Task<ErrorOr<Drink>> BuyDrink(Guid vendingMachineId, Guid drinkId, CancellationToken cancellationToken = default)
    {
        var vendingMachine = await _vendingMachineRepository.GetByIdAsync(vendingMachineId, cancellationToken);

        if(vendingMachine is null)
            return Errors.VendingMachineNotFound;

        var drink = await _drinkRepository.GetByIdAsync(drinkId, cancellationToken);

        if(drink is null)
            return Errors.DrinkNotFound;

        var balance = vendingMachine.GetBalance();

        if(balance < drink.Price)
            return Errors.InsufficientFunds;

        var change = balance - drink.Price;

        vendingMachine.SetBalance(change);

        vendingMachine.DecreaseCountDrinks();

        _vendingMachineRepository.Update(vendingMachine);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return drink;
    }

    public async Task<ErrorOr<Created>> CreateVendingMachine(List<Drink> drinks, List<Coin> coins, CancellationToken cancellationToken = default)
    {
        var vendingMachine = VendingMachine.Create(drinks, coins);

        await _vendingMachineRepository.AddAsync(vendingMachine.Value, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Created;
    }
}
