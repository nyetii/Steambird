using Microsoft.EntityFrameworkCore;
using Steambird.Server.Models;
using Steambird.Server.Repositories;

namespace Steambird.Server.Extensions;

public static class ServicesExtensions
{
    public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            #if DEBUG
            options.UseInMemoryDatabase("debug"));
            services.AddDatabaseDeveloperPageExceptionFilter();
            #else
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            #endif

        services.AddScoped<UnitOfWork>();
    }

    public static async Task CreateDatabaseAsync(this WebApplication app)
    {
        var context = app.Services.CreateAsyncScope().ServiceProvider.GetRequiredService<AppDbContext>();

        await context.Database.EnsureCreatedAsync();
    }
}