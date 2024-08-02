using DrinkDispenser.Application.Common.Interfaces;
using DrinkDispenser.Domain.Abstractions;
using DrinkDispenser.Domain.Entities;
using DrinkDispenser.Domain.Repositories;

namespace DrinkDispenser.Application.Services;

public class VendingMachinesService(
    IVendingMachineRepository vendingMachineRepository,
    IDrinkRepository drinkRepository,
    IUnitOfWork unitOfWork) : IVendingMachinesService
{
    public async Task<Drink> AddDrink(Guid vendingMachineId, Guid drinkId, CancellationToken cancellationToken = default)
    {
        var vendingMachine = await vendingMachineRepository
            .GetByIdAsync(vendingMachineId, cancellationToken);

        var drink = await drinkRepository
            .GetByIdAsync(drinkId, cancellationToken);

        vendingMachine.AddDrink(drink);

        await unitOfWork
            .SaveChangesAsync(cancellationToken);

        return drink;
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
