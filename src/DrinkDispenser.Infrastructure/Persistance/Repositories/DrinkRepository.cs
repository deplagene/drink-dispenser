using System.Runtime.CompilerServices;
using DrinkDispenser.Application.Common.Interfaces;
using DrinkDispenser.Domain.Drinks;
using Microsoft.EntityFrameworkCore;

namespace DrinkDispenser.Infrastructure.Persistance.Repositories;

public class DrinkRepository : IDrinkRepository
{
    private readonly ApplicationDbContext _dbcontext;

    public DrinkRepository(ApplicationDbContext dbcontext) => _dbcontext = dbcontext;

    public async Task AddAsync(Drink entity, CancellationToken cancellationToken = default)
    {
        await _dbcontext.Drinks.AddAsync(entity, cancellationToken);
    }

    public void Delete(Drink entity)
    {
        _dbcontext.Drinks.Remove(entity);
    }

    public async Task<IReadOnlyCollection<Drink>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbcontext
            .Drinks
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<IReadOnlyCollection<Drink>> GetAvailableDrinksAsync(CancellationToken cancellationToken = default)
    {
       return await _dbcontext
            .Drinks
            .Where(x => x.IsAvailable == true)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<Drink?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbcontext
            .Drinks
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public void Update(Drink entity)
    {
        _dbcontext.Drinks.Update(entity);
    }
}