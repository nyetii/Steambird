using Microsoft.EntityFrameworkCore;

namespace Steambird.Server.Models;

public class AppDbContext : DbContext
{
    public DbSet<Post> Posts { get; set; } = null!;
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>().HasData(
            new Post
            {
                Id = 1,
                Title = "This is a test post",
                Slug = "test",
                Content = "This is the content of that test post"
            }, new Post
            {
                Id = 2,
                Title = "Second post!",
                Slug = "second-post",
                Content = "Welcome to the second post on the blog."
            });
    }
}