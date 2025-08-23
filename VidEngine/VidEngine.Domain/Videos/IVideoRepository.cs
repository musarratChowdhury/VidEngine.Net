using VidEngine.Domain.Entity;
using VidEngine.Domain.Shared;

namespace VidEngine.Domain.Videos;

public interface IVideoRepository : IRepository<Video, Guid>
{
   Task<List<Video>> GetByUploaderAsync(string uploadedBy);
   Task<List<Video>> GetRecentlyUploadedAsync(int count);
}