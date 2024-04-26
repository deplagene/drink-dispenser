namespace DrinkDispenser.Contracts.Users;

public sealed record RegisterUserRequest(
    string UserName,
    string Password,
    string Email);