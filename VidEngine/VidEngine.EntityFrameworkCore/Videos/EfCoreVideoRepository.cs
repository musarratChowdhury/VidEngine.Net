using Microsoft.EntityFrameworkCore;
using VidEngine.Domain.Entity;
using VidEngine.Domain.Videos;
using VidEngine.EntityFrameworkCore.DbContexts;
using VidEngine.EntityFrameworkCore.Repositories;

namespace VidEngine.EntityFrameworkCore.Videos;

public class EfCoreVideoRepository : EfCoreRepository<Video, Guid>, IVideoRepository
{
    public EfCoreVideoRepository(AppDbContext context) : base(context) { }

    public async Task<List<Video>> GetByUploaderAsync(string uploadedBy)
    {
        return await _dbSet
            .Where(v => v.UploadedBy == uploadedBy)
            .OrderByDescending(v => v.UploadedAt)
            .ToListAsync();
    }

    public async Task<List<Video>> GetRecentlyUploadedAsync(int count)
    {
        return await _dbSet
            .OrderByDescending(v => v.UploadedAt)
            .Take(count)
            .ToListAsync();
    }
}