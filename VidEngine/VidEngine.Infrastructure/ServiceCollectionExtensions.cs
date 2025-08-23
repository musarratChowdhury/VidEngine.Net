using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VidEngine.Domain.Shared;
using VidEngine.Domain.Videos;
using VidEngine.EntityFrameworkCore.DbContexts;
using VidEngine.EntityFrameworkCore.Repositories;
using VidEngine.EntityFrameworkCore.Videos;

namespace VidEngine.Infrastructure;

public static class ServiceCollectionEnxtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddScoped(typeof(IRepository<,>), typeof(EfCoreRepository<,>));
        // Video repository
        services.AddScoped<IVideoRepository, EfCoreVideoRepository>();
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString,
                npgsqlOptions =>
                {
                    // Optional: specify migrations assembly (good if you keep migrations in EfCore project)
                    npgsqlOptions.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName);
                }));

        return services;
    }
}