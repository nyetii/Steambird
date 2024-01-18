using Steambird.Server.Models;
using Steambird.Server.Repositories.Milkshake;

namespace Steambird.Server.Repositories;

public class UnitOfWork(AppDbContext context) : IDisposable, IAsyncDisposable
{
    private PostRepository? _postRepository;
    public PostRepository PostRepository => _postRepository ??= new PostRepository(context);


    private TemplateRepository? _templateRepository;
    public TemplateRepository TemplateRepository => _templateRepository ??= new TemplateRepository(context);


    private SourceRepository? _sourceRepository;
    public SourceRepository SourceRepository => _sourceRepository ??= new SourceRepository(context);


    private ToppingRepository? _toppingRepository;
    public ToppingRepository ToppingRepository => _toppingRepository ??= new ToppingRepository(context);

    public int Save() => context.SaveChanges();
    public Task<int> SaveAsync() => context.SaveChangesAsync();

    public void Dispose()
    {
        context.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await context.DisposeAsync();
    }
}