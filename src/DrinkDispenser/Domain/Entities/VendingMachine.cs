using DrinkDispenser.Domain.Abstractions;

namespace DrinkDispenser.Domain.Entities;

public class VendingMachine : Entity<Guid>
{
    private readonly HashSet<Drink> _drinks = [];
    private readonly HashSet<Coin> _coins = [];

    public IReadOnlyCollection<Drink> Drinks => _drinks;
    public IReadOnlyCollection<Coin> Coins => _coins;
    public decimal Balance { get; private set; }
    public int AvailableDrinks { get; private set; }

    public static VendingMachine Create() => new VendingMachine();

    public void AddCoin(Coin coin)
    {
        _coins.Add(coin);
        Balance += coin.Nominal.Value;
    }

    public void AddDrink(Drink drink)
    {
        _drinks.Add(drink);
        AvailableDrinks = _drinks.Count;
    }

    public void BuyDrink(Drink drink)
    {
        _drinks.Remove(drink);
        Balance -= drink.Price.Value;
        AvailableDrinks = _drinks.Count;
    }
}