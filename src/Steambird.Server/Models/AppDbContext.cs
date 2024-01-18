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
                Title = "Milkshake.NET",
                Slug = "milkshake-net",
                CreatedAt = new DateTime(2024, 01, 15, 23, 59, 0),
                Content = "<p>Meu maior projeto até o momento. É possível usar ele neste site, <a href=\"/milkshake\">clicando aqui</a>.</p> <p><a href=\"https://github.com/nyetii/Milkshake.NET\">Repositório no GitHub</a></p>"

            },
            new Post
            {
                Id = 2,
                Title = "OpenGate",
                Slug = "open-gate",
                CreatedAt = new DateTime(2024, 01, 16, 23, 59, 0),
                Content = "<p>Este foi um pequeno projeto feito com meu amigo para conhecer LDAP e a Web API.</p> <p><a href=\"https://github.com/nyetii/OpenGate/tree/master\">Repositório no GitHub</a></p>"
                          
            },
            new Post
            {
                Id = 3,
                Title = "Selc",
                Slug = "selc",
                CreatedAt = new DateTime(2024, 01, 17, 23, 59, 0),
                Content = "<p>Utilizando a linguagem Swift, este foi um projeto em grupo durante uma extensão da faculdade no qual fizemos um aplicativo para iOS sobre o clima. Neste aplicativo, haviam coisas comuns como a previsão do tempo e notícias, porém o maior diferencial dele era a sua integração com um sensor de temperatura, pressão e umidade em Arduino, podendo salvar medições do mesmo.</p> <p><a href=\"https://drive.google.com/file/d/1NdpBSpMVHD8Z4t5gEmz9pg-uqvzy0HqJ/view?usp=sharing\">Arquivo .zip do Projeto</a></p>"

            },
            new Post
            {
                Id = 4,
                Title = "Bem-vindo ao meu blog!",
                Slug = "bem-vindo",
                CreatedAt = new DateTime(2024, 01, 18, 7, 30, 0),
                Content = """
                          Boas vindas ao meu blog! Eu planejo usar esta página como uma espécie de portfólio. Por ora só tem apenas uma pequena funcionalidade de blog e o gerador do Milkshake, porém planejo colocar mais projetos interessantes aqui.
                          """
            });

        modelBuilder.Entity<Template>().HasData(
            new Template()
            {
                Id = Guid.Parse("ee7dbb6e-2ea8-4f25-8654-1a32a1a35aac"),
                Name = "Nasce uma lenda",
                Description = "E morre outra",
                Path = @"C:\Users\Netty\Desktop\Repos\Steambird\src\Steambird.Server\Milkshake\template\Nasce uma lenda.webp",
                Tags = 0,
                Width = 554,
                Height = 484
            },
            new Template()
            {
                Id = Guid.Parse("ba062a8b-d601-4eff-875c-803c752a5ab5"),
                Name = "Perdeu tudo",
                Description = "Morando de aluguel",
                Path = @"C:\Users\Netty\Desktop\Repos\Steambird\src\Steambird.Server\Milkshake\template\perdeu tudo.webp",
                Tags = 0,
                Width = 1024,
                Height = 576
            },
            new Template()
            {
                Id = Guid.Parse("fab466dd-3e09-4d66-8873-1d62a6840d88"),
                Name = "Seu Madruga",
                Description = "Se olhando no espelho",
                Path = @"C:\Users\Netty\Desktop\Repos\Steambird\src\Steambird.Server\Milkshake\template\Seu Madruga.webp",
                Tags = 0,
                Width = 360,
                Height = 278
            });

        modelBuilder.Entity<Topping>().HasData(
            new Topping()
            {
                Id = Guid.NewGuid(),
                Name = "personagem1",
                Description = "",
                Width = 554,
                Height = 205,
                X = 0,
                Y = 50,
                Tags = ImageTags.Any,
                Layer = Layer.Background,
                IsText = false,
                TemplateId = Guid.Parse("ee7dbb6e-2ea8-4f25-8654-1a32a1a35aac"),
                Index = 1
            },
            new Topping()
            {
                Id = Guid.NewGuid(),
                Name = "personagem2",
                Description = "",
                Width = 554,
                Height = 205,
                X = 0,
                Y = 5289,
                Tags = ImageTags.Any,
                Layer = Layer.Background,
                IsText = false,
                TemplateId = Guid.Parse("ee7dbb6e-2ea8-4f25-8654-1a32a1a35aac"),
                Index = 2
            },

            new Topping()
            {
                Id = Guid.NewGuid(),
                Name = "personagem",
                Description = "",
                Width = 424,
                Height = 53,
                X = 491,
                Y = 77,
                Tags = ImageTags.Any,
                Layer = Layer.Foreground,
                IsText = true,
                Font = "Calibri",
                Color = "Black",
                TemplateId = Guid.Parse("ba062a8b-d601-4eff-875c-803c752a5ab5"),
                Index = 1
            },
            new Topping()
            {
                Id = Guid.NewGuid(),
                Name = "personagem",
                Description = "",
                Width = 518,
                Height = 446,
                X = 0,
                Y = 130,
                Tags = ImageTags.Any,
                Layer = Layer.Background,
                IsText = false,
                Font = "Calibri",
                Color = "Black",
                TemplateId = Guid.Parse("ba062a8b-d601-4eff-875c-803c752a5ab5"),
                Index = 1
            },

            new Topping()
            {
                Id = Guid.NewGuid(),
                Name = "personagem",
                Description = "",
                Width = 140,
                Height = 205,
                X = 61,
                Y = 22,
                Tags = ImageTags.Any,
                Layer = Layer.Background,
                IsText = false,
                Font = "Calibri",
                Color = "Black",
                TemplateId = Guid.Parse("fab466dd-3e09-4d66-8873-1d62a6840d88"),
                Index = 1
            });

        modelBuilder.Entity<Source>().HasData(
            new Source()
            {
                Name = "Ay que bestera",
                Description = "Ayyy",
                Tags = ImageTags.Any,
                Width = 539,
                Height = 417,
                Path = @"C:\Users\Netty\Desktop\Repos\Steambird\src\Steambird.Server\Milkshake\source\ay que bestera.webp"
            },
            new Source()
            {
                Name = "Fiat Uno",
                Description = "Uno vinho",
                Tags = ImageTags.Any,
                Width = 521,
                Height = 588,
                Path = @"C:\Users\Netty\Desktop\Repos\Steambird\src\Steambird.Server\Milkshake\source\Fiat Uno.webp"
            },
            new Source()
            {
                Name = "Internet Explorer",
                Description = "Navegador",
                Tags = ImageTags.Any,
                Width = 128,
                Height = 128,
                Path = @"C:\Users\Netty\Desktop\Repos\Steambird\src\Steambird.Server\Milkshake\source\Internet Explorer.webp"
            });
    }
}