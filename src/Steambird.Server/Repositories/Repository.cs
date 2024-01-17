using Microsoft.EntityFrameworkCore;
using Steambird.Server.Models;

namespace Steambird.Server.Repositories;

public class Repository<TEntity> where TEntity : class
{
    protected AppDbContext Context;
    protected DbSet<TEntity> Set;

    public Repository(AppDbContext context)
    {
        Context = context;
        Set = context.Set<TEntity>();
    }

    public virtual TEntity? Get(int id)
    {
        return Set.Find(id);
    }

    public virtual async ValueTask<TEntity?> GetAsync(int id)
    {
        return await Set.FindAsync(id);
    }

    public virtual IAsyncEnumerable<TEntity> GetAsync()
    {
        return Set.AsAsyncEnumerable();
    }

    public virtual void Add(TEntity entity)
    {
        Set.Add(entity);
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        await Set.AddAsync(entity);
    }

    public virtual void Update(TEntity entity)
    {

    }

    public virtual void Delete(int id) { }
}