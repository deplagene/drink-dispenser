using DrinkDispenser.Domain.Common.Errors.Users;
using DrinkDispenser.Domain.Common.Models;
using ErrorOr;

namespace DrinkDispenser.Domain.User;

public class User : Entity<Guid>
{
    public User(string userName, string password, string email)
    {
        UserName = userName;
        Password = password;
        Email = email;
        Roles = "User";
    }
    public string UserName { get; private set; } = null!;

    public string Password { get; private set; } = null!;

    public string Email { get; private set; } = null!;

    public string Roles { get; private set; } = null!;

    public static ErrorOr<User> Create(string userName, string password, string email)
    {
        if(string.IsNullOrEmpty(userName))
            return Errors.User.UserNameCannotBeEmpty;

        if(string.IsNullOrEmpty(password))
            return Errors.User.PasswordCannotBeEmpty;

        if(string.IsNullOrEmpty(email))
            return Errors.User.EmailCannotBeEmpty;

        return new User(userName, password, email);
    }
}