using DrinkDispenser.Domain.Coins;
using DrinkDispenser.Domain.Common.Errors.VendingMachines;
using DrinkDispenser.Domain.Common.Models;
using DrinkDispenser.Domain.Drinks;
using ErrorOr;

namespace DrinkDispenser.Domain.VendingMachines;

public class VendingMachine : Entity<Guid>
{
    private readonly HashSet<Drink> drinks = [];

    private readonly HashSet<Coin> coins = [];

    public IReadOnlyCollection<Drink> Drinks => drinks;

    public IReadOnlyCollection<Coin> Coins => coins;

    public decimal Balance { get; private set; } = 0;

    public int CountDrinks { get; private set; } = 0;

    public void SetBalance(decimal balance) => Balance = balance;

    public void UpdateBalance(int value) => Balance +=value;

    public void IncreaseCountDrinks() => CountDrinks ++;

    public void DecreaseCountDrinks() => CountDrinks --;

    public void SetCountDrinks(int count) => CountDrinks = count;

    public void AddCoin(Coin coin) => coins.Add(coin);

    public void AddDrink(Drink drink) => drinks.Add(drink);

    public ErrorOr<decimal> CalculateChange(Drink drink)
    {
        if(drink.NotAvailable())
            return Errors.DrinkNotAvailable;

        if(drink.Price > Balance)
            return Errors.InsufficientFunds;

        var change = Balance - drink.Price;

        return change;
    }
}