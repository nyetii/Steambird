using Microsoft.EntityFrameworkCore;
using Milkshake.Crud;
using Milkshake.Models;
using Steambird.Server.Models;

namespace Steambird.Server.Repositories.Milkshake;

public class ToppingRepository : Repository<Topping>, IMilkshakeHandler<Topping, ToppingRepository>
{
    public ToppingRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Topping?> Get(Guid id) => await Context.Toppings.FindAsync(id);

    public Task<ToppingRepository> GetMilkshake(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Topping[]> Get(string name)
    {
        throw new NotImplementedException();
    }

    public async Task<Topping[]> GetAll() => await Context.Toppings.ToArrayAsync();

    public async Task<Topping[]> GetAll(Guid id) => await Context.Toppings.Where(x => x.TemplateId == id).ToArrayAsync();

    public async Task Add(Topping media)
    {
        await base.AddAsync(media);
    }

    public async Task AddRangeAsync(IEnumerable<Topping> media) => await Context.Toppings.AddRangeAsync(media);

    public Task Update(Topping media, Guid id)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Topping media)
    {
        throw new NotImplementedException();
    }

    public Topping Build()
    {
        throw new NotImplementedException();
    }
}