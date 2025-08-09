using Microsoft.EntityFrameworkCore;
using VidEngine.Domain.Entity;

namespace VidEngine.EntityFrameworkCore.DbContexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Video> Videos => Set<Video>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // You can add entity configurations here
        modelBuilder.Entity<Video>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.Title).IsRequired().HasMaxLength(100);
        });
    }
}