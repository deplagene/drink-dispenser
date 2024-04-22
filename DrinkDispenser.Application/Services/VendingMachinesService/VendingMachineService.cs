using DrinkDispenser.Application.Common;
using DrinkDispenser.Application.Common.Interfaces;
using DrinkDispenser.Contracts.Drinks.Responses;
using DrinkDispenser.Domain.Coins;
using DrinkDispenser.Domain.Common.Abstractions;
using DrinkDispenser.Domain.Common.Errors.VendingMachines;
using DrinkDispenser.Domain.Drinks;
using DrinkDispenser.Domain.VendingMachines;
using ErrorOr;
using AutoMapper;

namespace DrinkDispenser.Application.Services.VendingMachinesService;

public class VendingMachineService : IVendingMachineService
{
    private readonly IVendingMachineRepository _vendingMachineRepository;
    private readonly IDrinkRepository _drinkRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public VendingMachineService(
        IVendingMachineRepository vendingMachineRepository,
        IUnitOfWork unitOfWork,
        IDrinkRepository drinkRepository,
        IMapper mapper)
    {
        _vendingMachineRepository = vendingMachineRepository;
        _unitOfWork = unitOfWork;
        _drinkRepository = drinkRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<Success>> AddCoinToVendingMachine(Guid vendingMachineId, Coin coin, CancellationToken cancellationToken = default)
    {
        var vendingMachine = await _vendingMachineRepository.GetByIdAsync(vendingMachineId, cancellationToken);

        if(vendingMachine is null)
            return Errors.VendingMachineNotFound;

        var validateCoin = Coin.IsValid(coin);

        if(!validateCoin)
            return Errors.InvalidCoin;

        vendingMachine.AddCoin(coin);

        vendingMachine.UpdateBalance(coin.Nominal);

        _vendingMachineRepository.Update(vendingMachine);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }

    public async Task<ErrorOr<Success>> AddDrinkToVendingMachine(Guid vendingMachineId, Guid drinkId, CancellationToken cancellationToken = default)
    {
        var vendingMachine = await _vendingMachineRepository.GetByIdAsync(vendingMachineId, cancellationToken);

        if(vendingMachine is null)
            return Errors.VendingMachineNotFound;

        var drink = await _drinkRepository.GetByIdAsync(drinkId, cancellationToken);

        if(drink is null)
            return Errors.DrinkNotFound;

        vendingMachine.IncreaseCountDrinks();

        vendingMachine.AddDrink(drink);

        _vendingMachineRepository.Update(vendingMachine);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success;
    }

    public async Task<ErrorOr<DrinkResponse>> BuyDrink(Guid vendingMachineId, Guid drinkId, CancellationToken cancellationToken = default)
    {
        var vendingMachine = await _vendingMachineRepository.GetByIdAsync(vendingMachineId, cancellationToken);

        if(vendingMachine is null)
            return Errors.VendingMachineNotFound;

        var drink = await _drinkRepository.GetByIdAsync(drinkId, cancellationToken);

        if(drink is null)
            return Errors.DrinkNotFound;

        var change = vendingMachine.CalculateChange(drink);

        vendingMachine.SetBalance(change.Value);

        vendingMachine.DecreaseCountDrinks();

        _vendingMachineRepository.Update(vendingMachine);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var drinkResponse = _mapper.Map<DrinkResponse>(drink);

        return drinkResponse;
    }

    public async Task<ErrorOr<Created>> CreateVendingMachine(CancellationToken cancellationToken = default)
    {
        var vendingMachine = new VendingMachine();

       await _vendingMachineRepository.AddAsync(vendingMachine);

       await _unitOfWork.SaveChangesAsync(cancellationToken);

       return Result.Created;
    }
}
