using Microsoft.EntityFrameworkCore;
using Milkshake.Models;

namespace Steambird.Server.Models;

public class AppDbContext : DbContext
{
    public DbSet<Post> Posts { get; set; } = null!;

    public DbSet<Template> Templates { get; set; } = null!;
    public DbSet<Source> Sources { get; set; } = null!;
    public DbSet<Topping> Toppings { get; set; } = null!;
    
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
                Content = """
                          Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse posuere porttitor enim, eget hendrerit massa auctor et. Etiam aliquet nulla tempor magna pulvinar dictum. Nam sodales purus consectetur, mollis metus in, dapibus ante. Praesent dignissim eu velit in vestibulum. Nulla ultrices consectetur nulla vel posuere. Fusce vestibulum faucibus nibh nec ullamcorper. Vestibulum imperdiet nisi nunc. Vestibulum id felis et turpis facilisis sagittis. Vivamus vestibulum nec elit ac imperdiet. Suspendisse eu congue lacus. Quisque elementum ante leo, non gravida mi luctus sed. Suspendisse potenti. Mauris quis diam vitae purus sodales consectetur.
                          
                          Vivamus placerat commodo nibh sed accumsan. Pellentesque sed sodales dolor. Donec at sem in diam posuere condimentum sit amet sit amet metus. In finibus egestas nibh. Nullam facilisis semper eleifend. Nam metus odio, faucibus ac mattis vitae, ornare sed tellus. Nam mattis rutrum leo non pellentesque. Nam et odio non sapien semper finibus et ac turpis. Sed euismod iaculis leo, ac ornare augue sodales a. Suspendisse potenti. Pellentesque a consequat sapien, sit amet luctus nibh.
                          
                          Maecenas finibus porttitor sapien, sit amet venenatis sem placerat quis. Cras at sagittis dui. Etiam tempor turpis vel tortor molestie, id egestas orci condimentum. Cras vitae venenatis urna. Nam id malesuada dui. Suspendisse condimentum scelerisque nibh, sit amet feugiat diam porta tristique. Nam ornare nibh felis, vitae varius nisl vulputate ac. Donec et quam eu nisi elementum ultricies. Etiam quis feugiat nisi, accumsan condimentum diam. Mauris sed sapien lacinia, sagittis enim at, sodales metus. Proin consequat magna ligula, sed vehicula eros aliquet eget. 
                          """
            }, new Post
            {
                Id = 2,
                Title = "Second post!",
                Slug = "second-post",
                Content = """
                          Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse posuere porttitor enim, eget hendrerit massa auctor et. Etiam aliquet nulla tempor magna pulvinar dictum. Nam sodales purus consectetur, mollis metus in, dapibus ante. Praesent dignissim eu velit in vestibulum. Nulla ultrices consectetur nulla vel posuere. Fusce vestibulum faucibus nibh nec ullamcorper. Vestibulum imperdiet nisi nunc. Vestibulum id felis et turpis facilisis sagittis. Vivamus vestibulum nec elit ac imperdiet. Suspendisse eu congue lacus. Quisque elementum ante leo, non gravida mi luctus sed. Suspendisse potenti. Mauris quis diam vitae purus sodales consectetur.
                          
                          Vivamus placerat commodo nibh sed accumsan. Pellentesque sed sodales dolor. Donec at sem in diam posuere condimentum sit amet sit amet metus. In finibus egestas nibh. Nullam facilisis semper eleifend. Nam metus odio, faucibus ac mattis vitae, ornare sed tellus. Nam mattis rutrum leo non pellentesque. Nam et odio non sapien semper finibus et ac turpis. Sed euismod iaculis leo, ac ornare augue sodales a. Suspendisse potenti. Pellentesque a consequat sapien, sit amet luctus nibh.
                          
                          Maecenas finibus porttitor sapien, sit amet venenatis sem placerat quis. Cras at sagittis dui. Etiam tempor turpis vel tortor molestie, id egestas orci condimentum. Cras vitae venenatis urna. Nam id malesuada dui. Suspendisse condimentum scelerisque nibh, sit amet feugiat diam porta tristique. Nam ornare nibh felis, vitae varius nisl vulputate ac. Donec et quam eu nisi elementum ultricies. Etiam quis feugiat nisi, accumsan condimentum diam. Mauris sed sapien lacinia, sagittis enim at, sodales metus. Proin consequat magna ligula, sed vehicula eros aliquet eget. 
                          """
            });

        modelBuilder.Entity<Template>().HasData(
            new Template()
            {
                Id = Guid.Parse("ee7dbb6e-2ea8-4f25-8654-1a32a1a35aac"),
                Name = "test",
                Description = "Test",
                Path = @"C:\Users\Netty\Desktop\Repos\Steambird\src\Steambird.Server\Milkshake\template\test.webp",
                Tags = 0,
                Width = 1024,
                Height = 755
            });

        modelBuilder.Entity<Topping>().HasData(
            new Topping()
            {
                Id = Guid.NewGuid(),
                Name = "test",
                Description = "test",
                Width = 400,
                Height = 400,
                X = 0,
                Y = 0,
                Tags = ImageTags.Any,
                Layer = Layer.Foreground,
                IsText = false,
                TemplateId = Guid.Parse("ee7dbb6e-2ea8-4f25-8654-1a32a1a35aac"),
                Index = 1
            });

        modelBuilder.Entity<Source>().HasData(
            new Source()
            {
                Name = "source test",
                Description = "source test",
                Tags = ImageTags.Any,
                Width = 635,
                Height = 635,
                Path = @"C:\Users\Netty\Desktop\Repos\Steambird\src\Steambird.Server\Milkshake\source\source test.webp"
            });
    }
}