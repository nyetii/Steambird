using Microsoft.EntityFrameworkCore;
using Milkshake.Crud;
using Milkshake.Models;
using Steambird.Server.Models;

namespace Steambird.Server.Repositories.Milkshake;

public class TemplateRepository : Repository<Template>, IMilkshakeHandler<Template, TemplateRepository>
{
    public TemplateRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Template?> Get(Guid id) => await Context.Templates.FindAsync(id);

    public Task<TemplateRepository> GetMilkshake(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Template[]> Get(string name)
    {
        throw new NotImplementedException();
    }

    public async Task<Template[]> GetAll() => await Context.Templates.ToArrayAsync();

    public Task<Template[]> GetAll(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task Add(Template media)
    {
        await base.AddAsync(media);
    }

    public Task Update(Template media, Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Template media)
    {
        throw new NotImplementedException();
    }

    public Template Build()
    {
        throw new NotImplementedException();
    }
}