using Microsoft.AspNetCore.Mvc;
using Steambird.Server.Dtos;
using Steambird.Server.Extensions;
using Steambird.Server.Models;
using Steambird.Server.Repositories;

namespace Steambird.Server.Controllers;

[Route("[controller]")]
public class PostController(UnitOfWork unitOfWork) : Controller
{
    // GET
    [HttpGet(Name = "GetPosts")]
    public IAsyncEnumerable<PostDto> Get()
    {
        return unitOfWork.PostRepository.GetAsync().ToDto();
    }

    [HttpGet("{date}/{slug}", Name = "GetPost")]
    public IActionResult Get(string date, string slug)
    {
        var post = unitOfWork.PostRepository.Get(date, slug).ToDto();

        if(post is null)
            return NotFound();

        return Ok(post);
    }
}