
namespace DrinkDispenser.Shared.Dtos;

public sealed record VendingMachineDto
{
    public Guid Id { get; init; }
    public decimal Balance { get; init; }
    public string Model { get; init; } = null!;
    public int CountOfAvailableDrinks { get; init; }
    public List<string> DrinksTitle { get; set; } = null!;
}