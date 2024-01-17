using System.ComponentModel.DataAnnotations;
using Steambird.Server.Extensions;

namespace Steambird.Server.Models;

public class Post
{
    public Post()
    {
        Title = $"Post {Id}";
    }

    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(128, ErrorMessage = "Title must be between up to 128 characters long")]
    public string Title { get; set; }

    public string? Description { get; set; }

    private readonly string _slug = string.Empty;

    [MaxLength(128, ErrorMessage = "Slug must be between up to 128 characters long")]
    public string Slug
    {
        get => _slug;
        init
        {
            if (string.IsNullOrWhiteSpace(value))
                _slug = Title.ToSlug();

            _slug = value.ToSlug();
        }
    }

    public DateTime CreatedAt => CreateTimestamp();

    public DateTime? UpdatedAt { get; set; } = null;

    public string Author { get; set; } = "Unknown";

    public string Content { get; set; } = string.Empty;



    private DateTime CreateTimestamp() => Id is 0 ? DateTime.MinValue : DateTime.Now;
}