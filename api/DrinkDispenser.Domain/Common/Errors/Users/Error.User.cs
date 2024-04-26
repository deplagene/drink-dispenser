using ErrorOr;

namespace DrinkDispenser.Domain.Common.Errors.Users;

public static partial class Errors
{
    public static class User
    {
        public static Error UserNameCannotBeEmpty => Error.Validation(
            code: "User.UserNameCannotBeEmpty",
            description: "User name cannot be empty"
        );

        public static Error PasswordCannotBeEmpty => Error.Validation(
            code: "User.PasswordCannotBeEmpty",
            description: "Password cannot be empty"
        );

        public static Error EmailCannotBeEmpty => Error.Validation(
            code: "User.EmailCannotBeEmpty",
            description: "Email cannot be empty"
        );

        public static Error UserNotFound => Error.NotFound(
            code: "User.UserNotFound",
            description: "User not found"
        );

        public static Error EmailNotUnique => Error.Validation(
            code: "User.EmailNotUnique",
            description: "Email not unique"
        );

        public static Error WrongPassword => Error.Validation(
            code: "User.WrongPassword",
            description: "Wrong password"
        );
    }
}