using DrinkDispenser.Domain.Common.Errors.VendingMachines;
using DrinkDispenser.Domain.Common.Models;
using DrinkDispenser.Domain.Drinks;
using ErrorOr;

namespace DrinkDispenser.Domain.VendingMachines;

public class VendingMachine : Entity<Guid>
{
    public VendingMachine(IReadOnlyCollection<Drink> drinks, IReadOnlyCollection<Coin> coins)
    {
        Drinks = drinks;
        Coins = coins;
    }
    public IReadOnlyCollection<Drink> Drinks { get; private set; }

    public IReadOnlyCollection<Coin> Coins { get; private set; }

    public static ErrorOr<VendingMachine> Create(IReadOnlyCollection<Drink> drinks, IReadOnlyCollection<Coin> coins)
    {
        if (drinks.Count == 0)
            return Errors.DrinksCannotBeEmpty;

        if (coins.Count == 0)
            return Errors.CoinsCannotBeEmpty;

        return new VendingMachine(drinks, coins);
    }
    // TODO: Add VendingMachine methods
}