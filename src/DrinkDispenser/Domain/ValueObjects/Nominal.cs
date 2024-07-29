using ErrorOr;

namespace DrinkDispenser.Domain.ValueObjects;

public record Nominal
{
    private Nominal(int value) => Value = value;

    private static readonly List<int> SupportedValues = [1, 2, 5, 10];

    public int Value { get; init; }

    public static ErrorOr<Nominal> Create(int value) => !SupportedValues.Contains(value)
            ? Error.Validation($"{value} не поддерживается. Поддерживаемые значения: {string.Join(", ", SupportedValues)}")
            : new Nominal(value);
}