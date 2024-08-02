using DrinkDispenser.Domain.Entities;

namespace DrinkDispenser.Application.Common.Interfaces;

public interface IVendingMachinesService
{
    Task<Drink> AddDrink(
        Guid vendingMachineId,
        Guid drinkId,
        CancellationToken cancellationToken = default);

    Task<Drink> BuyDrink(
        Guid vendingMachineId,
        Guid drinkId,
        CancellationToken cancellationToken = default);
}