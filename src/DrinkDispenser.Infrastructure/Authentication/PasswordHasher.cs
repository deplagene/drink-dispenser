using DrinkDispenser.Application.Common.Authentication;

namespace DrinkDispenser.Infrastructure.Authentication;

public class passwordHasher : IPasswordHasher
{
    public string Generate(string password)
        => BCrypt.Net.BCrypt.EnhancedHashPassword(password);

    public bool Verify(string hash, string password)
        => BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
}