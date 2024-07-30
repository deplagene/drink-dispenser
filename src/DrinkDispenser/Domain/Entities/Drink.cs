using DrinkDispenser.Domain.Abstractions;
using DrinkDispenser.Domain.ValueObjects;

namespace DrinkDispenser.Domain.Entities;

public class Drink : Entity<Guid>
{
    private Drink() { }
    private Drink(string name, Price price)
    {
        Name = name;
        Price = price;
        IsAvailable = true;
    }

    public string Name { get; private set; } = null!;
    public Price Price { get; private set; } = null!;
    public bool IsAvailable { get; private set; }

    public VendingMachine? VendingMachine { get; private set; } = null!;

    public static Drink Create(string name, decimal price) =>
         new Drink(name, Price.Create(price).Value);

    public void SetName(string value) => Name = value;

    public void SetPrice(decimal value) => Price = Price.Create(value).Value;
}