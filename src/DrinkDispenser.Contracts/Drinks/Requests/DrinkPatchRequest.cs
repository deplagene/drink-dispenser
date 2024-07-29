namespace DrinkDispenser.Contracts.Drinks.Requests;

public sealed record DrinkPatchRequest(
    string Name,
    decimal Price,
    string ImageUrl
);