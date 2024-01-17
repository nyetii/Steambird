using Steambird.Server.Models;
using System.Collections.Generic;
using Steambird.Server.Extensions;

namespace Steambird.Server.Repositories;

public class PostRepository : Repository<Post>
{
    public PostRepository(AppDbContext context) : base(context)
    {
    }

    public Post? Get(string? date, string? slug)
    {
        return Set.Where(post => post.Slug == slug)
            .ToList()
            .FirstOrDefault(post => post.CreatedAt.ToYearMonthString() == date);
        //context.Posts
        //    .Where(post => post.Slug == Slug)
        //    .ToList()
        //    .FirstOrDefault(post => post.CreatedAt.ToYearMonthString() == Date);
    }
}