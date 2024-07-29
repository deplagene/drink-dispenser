using DrinkDispenser.Domain.Coins;
using ErrorOr;

namespace DrinkDispenser.Domain.Common.Errors.Coins;

public static partial class Errors
{
    public static Error VendingMachineIdCannotBeEmpty => Error.Validation(
        code: "Coin:VendingMachineIdCannotBeEmpty",
        description: "Vending machine id cannot be empty");

    public static Error NominalMustBeGreaterThanZero => Error.Validation(
        code: "Coin:NominalMustBeGreaterThanZero",
        description: "Nominal must be greater than zero");

    public static Error CurrencyMustNotBeEmpty => Error.Validation(
        code: "Coin:CurrencyMustNotBeEmpty",
        description: "Currency must not be empty");

    public static Error NotSupportedCurrency => Error.Validation(
        code: "Coin:NotSupportedCurrency",
        description: "Not supported currency");

    public static Error InvalidNominal => Error.Validation(
        code: "Coin:InvalidNominal",
        description: "Invalid nominal");
}