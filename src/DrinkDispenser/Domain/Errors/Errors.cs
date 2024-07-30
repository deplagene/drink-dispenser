using ErrorOr;

namespace DrinkDispenser.Domain.Errors;

public static class Errors
{
    // Errors

    public static class Drinks
    {
        public static Error NotFound => Error.NotFound(
            code: "Drink.NotFound",
            description: "Напиток не найден, возможно он недоступен.");
    }
}