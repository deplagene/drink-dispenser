using DrinkDispenser.Domain.Coins;
using DrinkDispenser.Domain.Drinks;
using ErrorOr;

namespace DrinkDispenser.Application.Services.VendingMachinesService;

public interface IVendingMachineService
{
    Task<ErrorOr<Created>> CreateVendingMachine(List<Drink> drinks, List<Coin> coins, CancellationToken cancellationToken = default!);

    Task AddDrinksToVendingMachine(Guid vendingMachineId, List<Drink> drinks, CancellationToken cancellationToken = default!);

    Task<ErrorOr<Drink>> BuyDrink(Guid vendingMachineId, Guid drinkId, CancellationToken cancellationToken = default!);

    Task<ErrorOr<Success>> AddCoinToVendingMachine(Guid vendingMachineId, Coin coin, CancellationToken cancellationToken = default!);
}