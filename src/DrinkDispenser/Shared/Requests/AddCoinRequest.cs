namespace DrinkDispenser.Shared.Requests;

public sealed record AddCoinRequest
{
    public Guid CoinId { get; init; }
}