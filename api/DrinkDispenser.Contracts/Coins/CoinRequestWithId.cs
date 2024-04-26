namespace DrinkDispenser.Contracts.Coins;

public sealed record CoinRequestWithId(
    Guid Id,
    int Nominal,
    string Currency
);