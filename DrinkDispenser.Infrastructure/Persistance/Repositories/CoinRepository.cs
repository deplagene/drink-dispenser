using DrinkDispenser.Application.Common.Interfaces;
using DrinkDispenser.Domain.Coins;
using Microsoft.EntityFrameworkCore;

namespace DrinkDispenser.Infrastructure.Persistance.Repositories;

public class CoinRepository : ICoinRepository
{
    private readonly ApplicationDbContext _dbcontext;

    public CoinRepository(ApplicationDbContext dbcontext) => _dbcontext = dbcontext;

    public async Task AddAsync(Coin entity, CancellationToken cancellationToken = default)
    {
        await _dbcontext.Coins.AddAsync(entity, cancellationToken);
    }

    public void Delete(Coin entity)
    {
        _dbcontext.Coins.Remove(entity);
    }

    public async Task<Coin?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbcontext
            .Coins
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public void Update(Coin entity)
    {
        _dbcontext.Coins.Update(entity);
    }
}
