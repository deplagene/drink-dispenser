namespace DrinkDispenser.Contracts.Users;

public sealed record AuthenticationResult(string Token, UserDto User);