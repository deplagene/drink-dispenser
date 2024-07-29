namespace DrinkDispenser.Contracts.Drinks.Responses;

public sealed record DrinkResponse(
    string Name,
    decimal Price,
    string ImageUrl);