using DrinkDispenser.Application.Common.Interfaces;
using DrinkDispenser.Domain.User;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace DrinkDispenser.Infrastructure.Persistance.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbcontext;

    public UserRepository(ApplicationDbContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task AddAsync(User entity, CancellationToken cancellationToken = default)
    {
        await _dbcontext.Users.AddAsync(entity, cancellationToken);
    }

    public void Delete(User entity)
    {
        _dbcontext.Users.Remove(entity);
    }

    public async Task<IReadOnlyCollection<User>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbcontext
            .Users
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await _dbcontext
            .Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }

    public async Task<User?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbcontext
            .Users
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<bool> IsEmailUnique(string email, CancellationToken cancellationToken = default)
    {
        return ! await _dbcontext
            .Users
            .AsNoTracking()
            .AnyAsync(x => x.Email == email, cancellationToken);
    }

    public void Update(User entity)
    {
        _dbcontext.Users.Update(entity);
    }
}
