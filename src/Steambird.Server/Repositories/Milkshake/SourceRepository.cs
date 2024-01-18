using Microsoft.EntityFrameworkCore;
using Milkshake.Crud;
using Milkshake.Models;
using Steambird.Server.Models;

namespace Steambird.Server.Repositories.Milkshake;

public class SourceRepository : Repository<Source>, IMilkshakeHandler<Source, SourceRepository>
{
    public SourceRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Source?> Get(Guid id) => await Context.Sources.FindAsync(id);

    public Task<SourceRepository> GetMilkshake(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Source[]> Get(string name)
    {
        throw new NotImplementedException();
    }

    public async Task<Source[]> GetAll() => await Context.Sources.ToArrayAsync();

    public async Task<Source[]> GetAll(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task Add(Source media)
    {
        await base.AddAsync(media);
    }

    public Task Update(Source media, Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Source media)
    {
        throw new NotImplementedException();
    }

    public Source Build()
    {
        throw new NotImplementedException();
    }
}