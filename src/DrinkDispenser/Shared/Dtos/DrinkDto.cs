namespace DrinkDispenser.Shared.Dtos;

public sealed record DrinkDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = null!;
    public decimal Price { get; init; }
}