using ErrorOr;

namespace DrinkDispenser.Domain.Common.Errors.VendingMachines;

public static partial class Errors
{
    public static Error DrinksCannotBeEmpty =>
        Error.Validation(
            code: "VendingMachines.DrinksCannotBeEmpty",
            description: "Drinks cannot be empty.");

    public static Error CoinsCannotBeEmpty =>
        Error.Validation(
            code: "VendingMachines.CoinsCannotBeEmpty",
            description: "Coins cannot be empty.");
}