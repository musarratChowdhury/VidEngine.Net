

using VidEngine.Domain.Entity;
using VidEngine.Domain.Videos;

namespace VidEngine.Api.Services;

public class VideoService
{
    private readonly IVideoRepository _videoRepository;

    public VideoService(IVideoRepository videoRepository)
    {
        _videoRepository = videoRepository;
    }

    public async Task<Video?> GetVideoAsync(Guid id)
        => await _videoRepository.GetAsync(id);

    public async Task<List<Video>> GetAllVideosAsync()
        => await _videoRepository.GetAllAsync();

    public async Task<List<Video>> GetByUploaderAsync(string uploadedBy)
        => await _videoRepository.GetByUploaderAsync(uploadedBy);

    public async Task<List<Video>> GetRecentlyUploadedAsync(int count = 10)
        => await _videoRepository.GetRecentlyUploadedAsync(count);

    public async Task<Video> AddVideoAsync(Video video)
    {
        await _videoRepository.AddAsync(video);
        return video;
    }

    public async Task UpdateVideoAsync(Video video)
    {
        video.UpdatedAt = DateTime.UtcNow;
        await _videoRepository.UpdateAsync(video);
    }

    public async Task DeleteVideoAsync(Guid id)
        => await _videoRepository.DeleteAsync(id);
}