using DrinkDispenser.Application.Common.Interfaces.Base;
using DrinkDispenser.Domain.User;
using ErrorOr;

namespace DrinkDispenser.Application.Common.Interfaces;

public interface IUserRepository : IWriteUserRepository, IReadUserRepository
{
}

public interface IWriteUserRepository : IWriteRepository<User>
{
}

public interface IReadUserRepository : IReadRepository<User, Guid>
{
    Task<bool> IsEmailUnique(string email, CancellationToken cancellationToken = default!);

    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default!);
}