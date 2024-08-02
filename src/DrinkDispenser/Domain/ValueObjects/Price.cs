namespace DrinkDispenser.Domain.ValueObjects;

public record Price
{
    public decimal Value { get; init; }

    private Price(decimal value)
    {
        Value = value;
    }

    public static Price Create(decimal value)
        =>  value < 0 ? throw new ArgumentOutOfRangeException(nameof(value), "Цена не может быть отрицательной") : new Price(value);
}