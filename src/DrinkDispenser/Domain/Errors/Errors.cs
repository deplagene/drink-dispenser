using ErrorOr;

namespace DrinkDispenser.Domain.Errors;

public static class Errors
{
    public static class Drinks
    {
        public static Error NotFound => Error.NotFound(
            code: "Drink.NotFound",
            description: "Напиток не найден, возможно он недоступен.");
    }

    public static class VendingMachines
    {
        public static Error NotFound => Error.NotFound(
            code: "VendingMachines.NotFound",
            description: "Автомат не найден, попробуйте позже."
        );
    }

    public static class Coins
    {
        public static Error NotFound => Error.NotFound(
            code: "Coins.NotFound",
            description: "Монета не найдена"
        );
    }
}