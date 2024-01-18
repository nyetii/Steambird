using ImageMagick;
using Milkshake.Models;
using Milkshake.Models.Interfaces;

namespace Steambird.Server.Dtos;

public record ToppingDto()
{
    public string Name { get; set; } = "Nameless Topping";
    public string Description { get; set; } = "No description";
    public int Width { get; set; }
    public int Height { get; set; }
    public ImageTags Tags { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public Layer Layer { get; set; }
    public bool IsText { get; set; }
    public string? Color { get; set; }
    public Gravity Orientation { get; set; }
    public string? Font { get; set; }
    public string? StrokeColor { get; set; }
    public int StrokeWidth { get; set; }
    public Guid TemplateId { get; set; }
    public int Index { get; set; }
}