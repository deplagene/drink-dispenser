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

    public VendingMachine VendingMachine { get; private set; } = null!;

    public Guid? VendingMachineId { get; private set; }

    public static Drink Create(string name, decimal price)
    {
        return string.IsNullOrWhiteSpace(name)
            ? throw new ArgumentNullException("Название напитка не может быть пустым")
            : new Drink(name, Price.Create(price));
    }

    public void SetName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullException("Название напитка не может быть пустым");

        Name = value;
    }

    public void SetPrice(decimal value) => Price = Price.Create(value);

    public void SetAvailable(bool value) => IsAvailable = value;
}