using ErrorOr;

namespace DrinkDispenser.Domain.Common.Errors.Drinks;

public static partial class Errors
{
    public static Error InsufficientFunds =>
        Error.Validation(
            code: "Drinks.InsufficientFunds",
            description: "You don't have enough money to buy that drink.");
    public static Error NameCannotBeEmpty =>
        Error.Validation(
            code: "Drinks.NameCannotBeEmpty",
            description: "Name cannot be empty.");

    public static Error PriceMustBeGreaterThanZero =>
        Error.Validation(
            code: "Drinks.PriceMustBeGreaterThanZero",
            description: "Price must be greater than zero.");
}