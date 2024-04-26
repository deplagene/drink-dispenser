using DrinkDispenser.Contracts.Drinks.Responses;
using DrinkDispenser.Domain.Coins;
using DrinkDispenser.Domain.Drinks;
using ErrorOr;

namespace DrinkDispenser.Application.Services.VendingMachinesService;

public interface IVendingMachineService
{
    Task<ErrorOr<DrinkResponse>> BuyDrink(Guid vendingMachineId, Guid drinkId, CancellationToken cancellationToken = default!);

    Task<ErrorOr<Success>> AddCoinToVendingMachine(Guid vendingMachineId, int nominal, string currency, CancellationToken cancellationToken = default!);

    Task<ErrorOr<Success>> AddDrinkToVendingMachine(Guid vendingMachineId,
        string name,
        decimal price,
        string imageUrl,
        CancellationToken cancellationToken = default!);

    Task<ErrorOr<Created>> CreateVendingMachine(CancellationToken cancellationToken = default!);
}