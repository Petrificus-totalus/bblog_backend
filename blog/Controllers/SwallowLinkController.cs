using blog.Data;
using blog.Interfaces;
using blog.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers;

[Route("api/swallowlinks")]
[ApiController]
public class SwallowLinkController: ControllerBase
{
    private readonly ApplicationDBContext _context;
    private readonly ISwallowLinksRepository _swallowLinkRepo;
    public SwallowLinkController(ApplicationDBContext context, ISwallowLinksRepository swallowLinkRepo)
    {
        _context = context;
        _swallowLinkRepo = swallowLinkRepo;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var swallows = await _swallowLinkRepo.GetAllAsync();
        var swallowsDto = swallows.Select(s => s.ToSwallowLinkDto());
        return Ok(swallowsDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var swallowLink = await _swallowLinkRepo.GetByIdAsync(id);
        if(swallowLink == null) return NotFound();
        return Ok(swallowLink.ToSwallowLinkDto());
    }

}