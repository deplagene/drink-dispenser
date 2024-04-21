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

    public static Error VendingMachineNotFound =>
        Error.NotFound(
            code: "VendingMachines.VendingMachineNotFound",
            description: "Vending machine not found.");

    public static Error InvalidCoin => Error.Validation(
        code: "VendingMachines:InvalidCoin",
        description: "Invalid coin");

    public static Error DrinkNotFound => Error.NotFound(
        code: "VendingMachines.DrinkNotFound",
        description: "Drink not found.");

    public static Error InsufficientFunds => Error.Validation(
        code: "VendingMachine.InsufficientFunds",
        description: "Insufficient funds.");
}