namespace DrinkDispenser.Shared.Dtos;

public sealed record CoinDto
{
    public Guid Id { get; init; }
    public int Nominal { get; init; }
}