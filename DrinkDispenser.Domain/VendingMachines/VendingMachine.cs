using DrinkDispenser.Domain.Coins;
using DrinkDispenser.Domain.Common.Errors.VendingMachines;
using DrinkDispenser.Domain.Common.Models;
using DrinkDispenser.Domain.Drinks;
using ErrorOr;

namespace DrinkDispenser.Domain.VendingMachines;

public class VendingMachine : Entity<Guid>
{
    private VendingMachine() { }

    public VendingMachine(List<Drink> drinks, List<Coin> coins)
    {
        Drinks = drinks;
        Coins = coins;
    }

    public IReadOnlyCollection<Drink> Drinks {get; private set;}

    public IReadOnlyCollection<Coin> Coins {get; private set;}

    public decimal Balance { get; private set; }

    public static ErrorOr<VendingMachine> Create(List<Drink> drinks, List<Coin> coins)
    {
        if (drinks.Count == 0)
            return Errors.DrinksCannotBeEmpty;

        if (coins.Count == 0)
            return Errors.CoinsCannotBeEmpty;

        return new VendingMachine(drinks, coins);
    }
    public decimal GetBalance() => Balance;
}