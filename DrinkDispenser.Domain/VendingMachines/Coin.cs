using DrinkDispenser.Domain.Common.Errors.Coins;
using ErrorOr;

namespace DrinkDispenser.Domain.VendingMachines;

public record Coin
{
    private const string SUPPORTED_CURRENCY = "RUB";

    private static readonly IReadOnlyCollection<int> SupportedNominals = [1, 2, 5, 10];

    private Coin(decimal nominal, string currency)
    {
        Nominal = nominal;
        Currency = currency;
    }
    public decimal Nominal { get; private set; }

    public string Currency { get; private set; } = null!;

    public static ErrorOr<Coin> Create(int nominal, string currency)
    {
        if (nominal <= 0)
            return Errors.NominalMustBeGreaterThanZero;

        if(!SupportedNominals.Contains(nominal))
            return Errors.InvalidNominal;

        if (string.IsNullOrEmpty(currency))
            return  Errors.CurrencyMustNotBeEmpty;

        if (currency != SUPPORTED_CURRENCY)
            return Errors.NotSupportedCurrency;

        return new Coin(nominal, currency);
    }
}