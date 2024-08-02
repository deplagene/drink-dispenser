using DrinkDispenser.Domain.Entities;

namespace DrinkDispenser.Application.Common.Interfaces;

public interface IVendingMachinesService
{
    Task<VendingMachine> AddDrink(
        Guid vendingMachineId,
        Guid drinkId,
        CancellationToken cancellationToken = default);

    Task<Drink> BuyDrink(
        Guid vendingMachineId,
        Guid drinkId,
        CancellationToken cancellationToken = default);

    Task<VendingMachine> AddCoin(
        Guid vendingMachineId,
        Guid coinId,
        CancellationToken cancellationToken = default);
}