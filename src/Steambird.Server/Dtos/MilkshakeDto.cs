using Milkshake.Models;

namespace Steambird.Server.Dtos;

public record MilkshakeDto
{
    public string Name { get; init; } = "Nameless source";
    public string Description { get; init; } = "No description provided.";
    public ImageTags Tags { get; init; }
}

public record TemplateDto : MilkshakeDto
{
    public List<ToppingDto> Topping { get; init; } = new List<ToppingDto>();
}