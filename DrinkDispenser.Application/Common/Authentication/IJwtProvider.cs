using DrinkDispenser.Domain.User;

namespace DrinkDispenser.Application.Common.Authentication;

public interface IJwtProvider
{
    string GenerateToken(User user);
}