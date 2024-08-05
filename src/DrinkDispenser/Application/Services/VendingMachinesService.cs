using DrinkDispenser.Application.Common.Interfaces;
using DrinkDispenser.Domain.Abstractions;
using DrinkDispenser.Domain.Entities;
using DrinkDispenser.Domain.Repositories;

namespace DrinkDispenser.Application.Services;

public class VendingMachinesService(
    IVendingMachineRepository vendingMachineRepository,
    IDrinkRepository drinkRepository,
    ICoinRepository coinRepository,
    IUnitOfWork unitOfWork) : IVendingMachinesService
{
    public async Task<VendingMachine> AddCoin(Guid vendingMachineId, Guid coinId, CancellationToken cancellationToken = default)
    {
        var vendingMachine = await vendingMachineRepository
            .GetByIdAsync(vendingMachineId, cancellationToken);

        var coin = await coinRepository
            .GetByIdAsync(coinId, cancellationToken);

        if(await coinRepository.IsCoinExistsInVendingMachineAsync(vendingMachineId, coinId, cancellationToken))
            throw new InvalidOperationException("Монета уже добавлена в автомат.");

        vendingMachine.AddCoin(coin);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        return vendingMachine;
    }

    public async Task<VendingMachine> AddDrink(Guid vendingMachineId, Guid drinkId, CancellationToken cancellationToken = default)
    {
        var vendingMachine = await vendingMachineRepository
            .GetByIdAsync(vendingMachineId, cancellationToken);

        var drink = await drinkRepository
            .GetByIdAsync(drinkId, cancellationToken);

        if(await drinkRepository.IsDrinkExistsInVendingMachineAsync(vendingMachineId, drinkId, cancellationToken))
            throw new InvalidOperationException("Напиток уже добавлен в автомат.");

        vendingMachine.AddDrink(drink);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        return vendingMachine;
    }

    public async Task<Drink> BuyDrink(Guid vendingMachineId, Guid drinkId, CancellationToken cancellationToken = default)
    {
        var vendingMachine = await vendingMachineRepository
            .GetByIdAsync(vendingMachineId, cancellationToken);

        var drink = await drinkRepository
            .GetByIdAsync(drinkId, cancellationToken);

        vendingMachine.BuyDrink(drink);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        return drink;
    }
}
