using Microsoft.EntityFrameworkCore;
using VidEngine.Domain.Shared;
using VidEngine.EntityFrameworkCore.DbContexts;

namespace VidEngine.EntityFrameworkCore.Repositories;

public class EfCoreRepository<TEntity, TKey> : IRepository<TEntity, TKey>
    where TEntity : class
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public EfCoreRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }
    
    public async Task<TEntity?> GetAsync(TKey id)
        => await _dbSet.FindAsync(id);

    public async Task<List<TEntity>> GetAllAsync()
        => await _dbSet.ToListAsync();

    public async Task AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TKey id)
    {
        var entity = await GetAsync(id);
        if (entity != null)
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}