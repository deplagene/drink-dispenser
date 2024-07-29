namespace DrinkDispenser.Contracts.Drinks;

public sealed record DrinkRequest(
    string Name,
    decimal Price,
    string ImageUrl,
    Guid VendingMachineId);