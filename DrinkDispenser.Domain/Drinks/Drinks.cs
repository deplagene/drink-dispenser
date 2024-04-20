using DrinkDispenser.Domain.Common.Errors.Drinks;
using DrinkDispenser.Domain.Common.Models;
using DrinkDispenser.Domain.VendingMachines;
using ErrorOr;

namespace DrinkDispenser.Domain.Drinks;

public class Drink : Entity<Guid>
{
    private Drink(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
    public string Name { get; private set; } = null!;

    public decimal Price { get; private set; }

    public VendingMachine VendingMachine { get; private set; }

    public static ErrorOr<Drink> Create(string name, decimal price)
    {
        if (string.IsNullOrEmpty(name))
            return Errors.NameCannotBeEmpty;

        if (price <= 0)
            return Errors.PriceMustBeGreaterThanZero;

        return new Drink(name, price);
    }

    // TODO: Add more methods
}