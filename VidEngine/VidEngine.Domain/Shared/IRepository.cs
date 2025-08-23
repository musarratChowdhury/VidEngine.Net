namespace VidEngine.Domain.Shared;

public interface IRepository<TEntity, TKey> where TEntity:class
{
    Task<TEntity?> GetAsync(TKey id);
    Task<List<TEntity>> GetAllAsync();
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TKey id);
}

public interface IRepository<TEntity> : IRepository<TEntity, Guid> where TEntity : class { }
