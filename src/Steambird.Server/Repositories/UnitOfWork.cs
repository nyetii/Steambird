using Steambird.Server.Models;

namespace Steambird.Server.Repositories;

public class UnitOfWork(AppDbContext context) : IDisposable, IAsyncDisposable
{
    private PostRepository? _postRepository;

    public PostRepository PostRepository => _postRepository ??= new PostRepository(context);

    public void Dispose()
    {
        context.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await context.DisposeAsync();
    }
}