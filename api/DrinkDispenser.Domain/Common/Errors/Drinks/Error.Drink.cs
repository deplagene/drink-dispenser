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

    public static Error ImageUrlCannotBeEmpty =>
        Error.Validation(
            code: "Drinks.ImageUrlCannotBeEmpty",
            description: "Image URL cannot be empty.");

    public static Error InvalidImageUrl =>
        Error.Validation(
            code: "Drinks.InvalidImageUrl",
            description: "Invalid image URL.");

    public static Error NotFound =>
        Error.NotFound(
            code: "Drinks.NotFound",
            description: "Drink not found.");

    public static Error DrinksNotFound =>
        Error.NotFound(
            code: "Drinks.NotFound",
            description: "Drinks not found.");

    public static Error VendingMachineIdCannotBeEmpty =>
        Error.Validation(
            code: "Drinks.VendingMachineIdCannotBeEmpty",
            description: "Vending machine ID cannot be empty.");

    public static Error AvailabilityCannotBeEmpty =>
        Error.Validation(
            code: "Drinks.AvailabilityCannotBeEmpty",
            description: "Availability cannot be empty.");

    public static Error VendingMachineNotFound =>
        Error.NotFound(
            code: "Drinks.VendingMachineNotFound",
            description: "Vending machine not found.");
}