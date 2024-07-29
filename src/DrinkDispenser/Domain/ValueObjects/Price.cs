using ErrorOr;

namespace DrinkDispenser.Domain.ValueObjects;

public record Price
{
    public decimal Value { get; init; }

    private Price(decimal value)
    {
        Value = value;
    }

    public static ErrorOr<Price> Create(decimal value)
        =>  value < 0 ? Error.Validation("Price cannot be negative") : new Price(value);
}