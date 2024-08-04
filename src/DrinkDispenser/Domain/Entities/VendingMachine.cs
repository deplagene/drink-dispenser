using DrinkDispenser.Domain.Abstractions;

namespace DrinkDispenser.Domain.Entities;

public class VendingMachine : Entity<Guid>
{
    private VendingMachine() { }

    private VendingMachine(string model)
    {
        Model = model;
        Balance = 0;
    }
    private readonly HashSet<Drink> _drinks = [];
    private readonly HashSet<Coin> _coins = [];

    public IReadOnlyCollection<Drink> Drinks => _drinks;
    public IReadOnlyCollection<Coin> Coins => _coins;
    public decimal Balance { get; private set; }
    public int CountOfAvailableDrinks { get; private set; }

    public string Model { get; private set; } = null!;

    public static VendingMachine Create(string model)
    {
        return string.IsNullOrWhiteSpace(model)
            ? throw new ArgumentNullException(nameof(model), "Model can't be null")
            : new VendingMachine(model);
    }

    public void AddCoin(Coin coin)
    {
        _coins.Add(coin);
        Balance += coin.Nominal.Value;
    }

    public void AddDrink(Drink drink)
    {
        _drinks.Add(drink);
        CountOfAvailableDrinks = _drinks.Count;
    }

    public void BuyDrink(Drink drink)
    {
        if(Balance <= 0)
            throw new InvalidOperationException("Недостаточно средств для покупки напитка.");

        if(drink.Price.Value > Balance)
            throw new InvalidOperationException("Недостаточно средств для покупки напитка.");

        Balance -= drink.Price.Value;
        CountOfAvailableDrinks = _drinks.Count;
        drink.SetAvailableToFalse();
        _drinks.Remove(drink);
    }
}