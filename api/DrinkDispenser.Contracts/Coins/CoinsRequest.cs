namespace DrinkDispenser.Contracts.Coins;

public sealed record CoinRequest(
    int Nominal,
    string Currency
);