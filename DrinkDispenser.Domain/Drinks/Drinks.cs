using DrinkDispenser.Domain.Common.Errors.Drinks;
using DrinkDispenser.Domain.Common.Models;
using DrinkDispenser.Domain.VendingMachines;
using ErrorOr;

namespace DrinkDispenser.Domain.Drinks;

public class Drink : Entity<Guid>
{
    private Drink() { }

    private Drink(string name, decimal price, string imageUrl)
    {
        Name = name;
        Price = price;
        ImageUrl = imageUrl;
    }
    public string Name { get; private set; } = null!;

    public decimal Price { get; private set; }

    public string ImageUrl { get; private set; }

    public int Count { get; private set; } = 0;

    public Guid VendingMachineId { get; private set; }

    public VendingMachine VendingMachine { get; private set; }

    public static ErrorOr<Drink> Create(string name, decimal price, string imageUrl)
    {
        if (string.IsNullOrEmpty(name))
            return Errors.NameCannotBeEmpty;

        if (price <= 0)
            return Errors.PriceMustBeGreaterThanZero;

        if(string.IsNullOrEmpty(imageUrl))
            return Errors.ImageUrlCannotBeEmpty;

        return new Drink(name, price, imageUrl);
    }

    public void SetName(string name)
    {
        Name = name;
    }

    public void SetPrice(decimal price)
    {
        Price = price;
    }

    public void SetImageUrl(string imageUrl)
    {
        ImageUrl = imageUrl;
    }

    public void SetCount(int count)
    {
        Count = count;
    }

    public void IncreaseCount()
    {
        Count++;
    }

    public void DecreaseCount()
    {
        Count--;
    }
}