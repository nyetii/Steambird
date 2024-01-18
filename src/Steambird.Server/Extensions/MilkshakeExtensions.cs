using System.IO;
using System.Xml;
using ImageMagick;
using Microsoft.EntityFrameworkCore.Design;
using Milkshake.Builders;
using Milkshake.Models;
using Milkshake.Models.Interfaces;
using Steambird.Server.Dtos;

namespace Steambird.Server.Extensions;

public static class MilkshakeExtensions
{
    public static Template ToTemplate(this MilkshakeDto dto)
    {
        return new Template
        {
            Name = dto.Name,
            Description = dto.Description,
            Tags = dto.Tags,
            MilkshakeContextId = Guid.Empty,
            Milkshake = null!,
        };
    }

    public static Source ToSource(this MilkshakeDto dto)
    {
        return new Source
        {
            Name = dto.Name,
            Description = dto.Description,
            Tags = dto.Tags,
            MilkshakeContextId = Guid.Empty,
            Milkshake = null!,
        };
    }

    public static Topping ToTopping(this ToppingDto dto)
    {
        return new Topping()
        {
            Name = dto.Name,
            Description = dto.Description,
            Tags = dto.Tags,
            Width = dto.Width,
            Height = dto.Height,
            X = dto.X,
            Y = dto.Y,
            Layer = dto.Layer,
            IsText = dto.IsText,
            Color = dto.Color ?? "black",
            Orientation = dto.Orientation,
            Font = dto.Font ?? "Arial",
            StrokeColor = dto.StrokeColor ?? "black",
            StrokeWidth = dto.StrokeWidth,
            TemplateId = dto.TemplateId,
            Index = dto.Index
        };
    }

    public static ToppingDto ToDto(this Topping topping)
    {
        return new ToppingDto()
        {
            Name = topping.Name,
            Description = topping.Description,
            Tags = topping.Tags,
            Width = topping.Width,
            Height = topping.Height,
            X = topping.X,
            Y = topping.Y,
            Layer = topping.Layer,
            IsText = topping.IsText,
            Color = topping.Color,
            Orientation = topping.Orientation,
            Font = topping.Font,
            StrokeColor = topping.StrokeColor,
            StrokeWidth = topping.StrokeWidth,
            TemplateId = topping.TemplateId,
            Index = topping.Index
        };
    }

    public static ICollection<Topping> ToTopping(this IList<ToppingDto> dto)
    {
        var array = new Topping[dto.Count];

        for (int i = 0; i < array.Length; i++)
            array[i] = dto[i].ToTopping();

        return array;
    }

    public static ICollection<ToppingDto> ToDto(this IList<Topping> topping)
    {
        var array = new ToppingDto[topping.Count];

        for (int i = 0; i < array.Length; i++)
            array[i] = topping[i].ToDto();

        return array;
    }

    public static async Task SaveWebp(this IFormFile file, (int width, int height) limit, string path)
    {
        await using var readStream = file.OpenReadStream();
        await using var stream = new MemoryStream();

        await readStream.CopyToAsync(stream);

        stream!.Position = 0;
        using var image = new MagickImage(stream);

        if (image.Width > limit.width || image.Height > limit.height)
        {
            var resize = new MagickGeometry();
            resize.Width = limit.width;
            resize.Height = limit.height;
            //resize.FillArea = true;

            resize.IgnoreAspectRatio = false;

            image.AdaptiveResize(resize);
        }

        image.Format = MagickFormat.WebP;

        stream.Position = 0;
        await image.WriteAsync(stream);
        
        stream.Position = 0;
        using var output = new MagickImage(stream);
        stream.Position = 0;
        await using var filestream = new FileStream($"{path}", FileMode.CreateNew);
        await output.WriteAsync(filestream);
    }

    public static (int width, int height) SetDimensions(this IMedia media)
    {
        using var image =
            new MagickImage(media.Path);
        
        return (image.Width, image.Height);
    }

}