using DrinkDispenser.Domain.Common.Errors.Coins;
using DrinkDispenser.Domain.Common.Models;
using DrinkDispenser.Domain.VendingMachines;
using ErrorOr;

namespace DrinkDispenser.Domain.Coins;

public class Coin : Entity<Guid>
{
    private const string SUPPORTED_CURRENCY = "RUB";

    private static readonly IReadOnlyCollection<int> SupportedNominals = [1, 2, 5, 10];

    private Coin(int nominal, string currency)
    {
        Nominal = nominal;
        Currency = currency;
    }
    public int Nominal { get; private set; }

    public string Currency { get; private set; } = null!;

    public bool IsBlocked { get; private set; }

    public VendingMachine VendingMachine { get; set; }

    public Guid VendingMachineId { get; private set; }

    public static ErrorOr<Coin> Create(int nominal, string currency)
    {
        if (nominal <= 0)
            return Errors.NominalMustBeGreaterThanZero;

        if(!SupportedNominals.Contains(nominal))
            return Errors.InvalidNominal;

        if (string.IsNullOrEmpty(currency))
            return  Errors.CurrencyMustNotBeEmpty;

        if (currency.ToUpper() != SUPPORTED_CURRENCY)
            return Errors.NotSupportedCurrency;

        return new Coin(nominal, currency);

    }

    public static bool IsValid(Coin coin)
    {
        if(!SupportedNominals.Contains(coin.Nominal))
            return false;

        if(string.IsNullOrEmpty(coin.Currency))
            return false;

        if(coin.Currency.ToUpper() != SUPPORTED_CURRENCY)
            return false;

        if(coin.Nominal <= 0)
            return false;

        return true;
    }
}