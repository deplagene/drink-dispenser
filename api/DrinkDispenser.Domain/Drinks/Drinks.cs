using DrinkDispenser.Domain.Common.Errors.Drinks;
using DrinkDispenser.Domain.Common.Models;
using DrinkDispenser.Domain.VendingMachines;
using ErrorOr;

namespace DrinkDispenser.Domain.Drinks;

public class Drink : Entity<Guid>
{
    private Drink() { }

    private Drink(string name, decimal price, string imageUrl, Guid vendingMachineId)
    {
        Name = name;
        Price = price;
        ImageUrl = imageUrl;
        IsAvailable = true;
        VendingMachineId = vendingMachineId;
    }
    public string Name { get; private set; } = null!;

    public decimal Price { get; private set; }

    public string ImageUrl { get; private set; }

    public bool IsAvailable { get; private set; }

    public Guid VendingMachineId { get; private set; }

    public VendingMachine VendingMachine { get; private set; }

    public static ErrorOr<Drink> Create(string name, decimal price, string imageUrl, Guid vendingMachineId)
    {
        if (string.IsNullOrEmpty(name))
            return Errors.NameCannotBeEmpty;

        if (price <= 0)
            return Errors.PriceMustBeGreaterThanZero;

        if(string.IsNullOrEmpty(imageUrl))
            return Errors.ImageUrlCannotBeEmpty;

        if(!Uri.TryCreate(imageUrl, UriKind.Absolute, out var uri))
            return Errors.InvalidImageUrl;

        if(Guid.Empty == vendingMachineId)
            return Errors.VendingMachineIdCannotBeEmpty;

        return new Drink(name, price, imageUrl, vendingMachineId);
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
    public bool NotAvailable() => !IsAvailable;

    public void SetAvailability(bool isAvailable)
    {
        IsAvailable = isAvailable;
    }
}