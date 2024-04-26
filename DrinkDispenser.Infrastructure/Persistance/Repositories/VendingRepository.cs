using DrinkDispenser.Application.Common;
using DrinkDispenser.Domain.VendingMachines;
using Microsoft.EntityFrameworkCore;

namespace DrinkDispenser.Infrastructure.Persistance.Repositories;

public class VendingMachineRepository : IVendingMachineRepository
{
    private readonly ApplicationDbContext _dbContext;

    public VendingMachineRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

    public async Task AddAsync(VendingMachine entity, CancellationToken cancellationToken = default)
    {
        await _dbContext.VendingMachines.AddAsync(entity, cancellationToken);
    }

    public void Delete(VendingMachine entity)
    {
        _dbContext.VendingMachines.Remove(entity);
    }

    public async Task<IReadOnlyCollection<VendingMachine>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext
            .VendingMachines
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<VendingMachine?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext
            .VendingMachines
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public void Update(VendingMachine entity)
    {
        _dbContext.VendingMachines.Update(entity);
    }
}
