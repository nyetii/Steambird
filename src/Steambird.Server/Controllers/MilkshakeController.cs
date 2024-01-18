using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Milkshake;
using Milkshake.Builders;
using Milkshake.Generation;
using Milkshake.Managers;
using Milkshake.Models;
using Milkshake.Models.Interfaces;
using Serilog;
using Serilog.Events;
using Steambird.Server.Dtos;
using Steambird.Server.Extensions;
using Steambird.Server.Repositories;
using Steambird.Server.Repositories.Milkshake;

namespace Steambird.Server.Controllers;

[Route("[controller]")]
public class MilkshakeController(UnitOfWork unitOfWork, GenerationQueue generation, MilkshakeService milkshake) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var path = $"{milkshake.Options.BasePath}/cache";
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        var sources = await unitOfWork.SourceRepository.GetAll();

        var templates = await unitOfWork.TemplateRepository.GetAll();
        var template = templates[Random.Shared.Next(0, templates.Length)];
        template.Toppings = await unitOfWork.ToppingRepository.GetAll(template.Id);

        var gen = new Generation()
        {
            Caller = "Unknown",
            Sources = sources.ToList(),
            Template = template
        };
        
        generation.Enqueue(gen);

        var cancellationToken = new CancellationTokenSource();
        generation.ImageGenerated += async (sender, args) =>
        {
            if(args.Id != gen.Id)
                return;

            await cancellationToken.CancelAsync();
            path = args.FilePath;
        };

        await generation.Generate();

        await Delay();

        var stream = System.IO.File.OpenRead(path);

        return File(stream, "image/png");

        async Task Delay()
        {
            try
            {
                await Task.Delay(-1, cancellationToken.Token);
            }
            catch (TaskCanceledException)
            {
            }
        }
    }

    #region Sources
    [HttpGet("source")]
    public async Task<IActionResult> GetSource()
    {
        var sources = await unitOfWork.SourceRepository.GetAll();

        return Ok(sources);
    }

    [HttpPost("source")]
    public async Task<IActionResult> PostSource(MilkshakeDto sourceDto, IFormFile file)
    {
        var path = $"{milkshake.Options.BasePath}/source";
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        path += $"/{sourceDto.Name}.webp";

        await file.SaveWebp(milkshake.Options.MaxDimensions, path);

        var source = sourceDto.ToSource();
        //var template = new TemplateBuilder(milkshake, new ContextData())
        //    .WithName(sourceDto.Name)
        //    .WithDescription(sourceDto.Description)
        //    .WithTags(sourceDto.Tags)
        //    .Build();

        source.Path = path;
        (source.Width, source.Height) = source.SetDimensions();

        await unitOfWork.SourceRepository.AddAsync(source);

        await unitOfWork.SaveAsync();

        return Created();
    }
    #endregion

    #region Templates

    [HttpGet("template")]
    public async Task<IActionResult> GetTemplate()
    {
        var templates = unitOfWork.TemplateRepository.GetAll().Result.FirstOrDefault();
        //templates.Toppings = await unitOfWork.ToppingRepository.GetAll(Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"));
        var toppings = await unitOfWork.ToppingRepository.GetAll();

        templates.Toppings = toppings.Where(x => x.TemplateId == templates.Id).ToArray();

        Log.Write(LogEventLevel.Information, templates.Id.ToString());

        var dto = new TemplateDto()
        {
            Name = templates.Name,
            Description = templates.Description,
            Tags = templates.Tags,
            Topping = toppings.ToDto().ToList()
        };

        return Ok(dto);
    }

    [HttpPost("template")]
    public async Task<IActionResult> PostTemplate(MilkshakeDto templateDto, IFormFile file)
    {
        var path = $"{milkshake.Options.BasePath}/template";
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);

        path += $"/{templateDto.Name}.webp";

        await file.SaveWebp(milkshake.Options.MaxDimensions, path);

        var template = templateDto.ToTemplate();
        //var template = new TemplateBuilder(milkshake, new ContextData())
        //    .WithName(sourceDto.Name)
        //    .WithDescription(sourceDto.Description)
        //    .WithTags(sourceDto.Tags)
        //    .Build();

        template.Path = path;
        (template.Width, template.Height) = template.SetDimensions();

        await unitOfWork.TemplateRepository.AddAsync(template);
        
        await unitOfWork.SaveAsync();

        return Created();
    }
    #endregion

    #region Topping
    [HttpPost("topping")]
    public async Task<IActionResult> PostTopping([FromBody]List<ToppingDto> toppingDtos)
    {
        var topping = toppingDtos.ToArray().ToTopping();

        await unitOfWork.ToppingRepository.AddRangeAsync(topping);

        await unitOfWork.SaveAsync();

        return Created();
    }


    #endregion
}
