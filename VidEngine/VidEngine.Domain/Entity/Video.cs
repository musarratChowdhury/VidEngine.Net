namespace VidEngine.Domain.Entity;

public class Video
{
    public Guid Id { get; set; } = Guid.NewGuid();

    // Basic video details
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string FilePath { get; set; } = default!; // local or cloud path
    public string ThumbnailUrl { get; set; } = default!;

    // Metadata
    public TimeSpan Duration { get; set; }
    public long FileSizeBytes { get; set; }
    public string Format { get; set; } = default!; // e.g., mp4, mkv
    public DateTime UploadedAt { get; set; } = DateTime.UtcNow;
    public string UploadedBy { get; set; } = default!; // uploader name or user ID

    // Download tracking
    public string? DownloadedBy { get; set; } // null if not downloaded yet
    public DateTime? DownloadedAt { get; set; }

    // Audit
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}