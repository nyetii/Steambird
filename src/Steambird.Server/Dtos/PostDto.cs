using System.Globalization;
using Steambird.Server.Models;

namespace Steambird.Server.Dtos;

public record PostDto
{
    private readonly Post _post;

    public PostDto(Post post) => _post = post;

    public int Id => _post.Id;
    public string Title => _post.Title;
    public string? Description => _post.Description;
    public string Slug => _post.Slug;
    public string CreatedAt => _post.CreatedAt.ToUniversalTime().ToString(CultureInfo.InvariantCulture);
    public string? UpdatedAt => _post.UpdatedAt?.ToString("dd/MM/yyyy HH:mm");
    public string Author => _post.Author;
    public string Content => _post.Content;
}