namespace DrinkDispenser.Application.Common.Authentication;

public interface IPasswordHasher
{
    string Generate(string password);

    bool Verify(string hash, string password);
}