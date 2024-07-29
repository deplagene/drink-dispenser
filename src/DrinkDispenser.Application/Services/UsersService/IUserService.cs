using DrinkDispenser.Contracts.Users;
using ErrorOr;

namespace DrinkDispenser.Application.Services.UsersService;

public interface IUserService
{
    Task<ErrorOr<Success>> RegisterUser(string userName, string password, string email, CancellationToken cancellationToken = default);

    Task<ErrorOr<AuthenticationResult>> LoginUser(string email, string password, CancellationToken cancellationToken = default);
}