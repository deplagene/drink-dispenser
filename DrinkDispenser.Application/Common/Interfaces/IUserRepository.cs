using DrinkDispenser.Application.Common.Interfaces.Base;
using DrinkDispenser.Domain.User;
using ErrorOr;

namespace DrinkDispenser.Application.Common.Interfaces;

public interface IUserRepository : IUserWriteRepository, IUserReadRepository
{
}

public interface IUserWriteRepository : IWriteRepository<User>
{
}

public interface IUserReadRepository : IReadRepository<User, Guid>
{
    Task<bool> IsEmailUnique(string email, CancellationToken cancellationToken = default!);

    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default!);
}