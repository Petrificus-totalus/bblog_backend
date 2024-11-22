using blog.Data;
using blog.Dtos.Swallow;
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
    private readonly ISwallowRepository _swallowRepo;

    public SwallowLinkController(ApplicationDBContext context, ISwallowLinksRepository swallowLinkRepo, ISwallowRepository swallowRepo)
    {
        _context = context;
        _swallowLinkRepo = swallowLinkRepo;
        _swallowRepo = swallowRepo;
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
    
    
    [HttpPost("{swallowId}")]
    public async Task<IActionResult> Create([FromRoute] int swallowId, CreateLinkDto linkDto)
    {
       if(!await _swallowRepo.SwallowExist(swallowId)) return BadRequest("Swallow does not exist");
       var swallowLink = linkDto.ToSwallowLinkFromCreate(swallowId);
       await _swallowLinkRepo.CreateAsync(swallowLink);
       return CreatedAtAction(nameof(GetById), new { id = swallowLink.Id }, swallowLink.ToSwallowLinkDto());
    }
    
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var swallowLink = await _swallowLinkRepo.DeleteAsync(id);
        if(swallowLink == null) return NotFound("Link does not exist");
        return NoContent();
    }
}