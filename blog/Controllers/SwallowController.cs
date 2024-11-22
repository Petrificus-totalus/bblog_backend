using blog.Data;
using blog.Dtos.Swallow;
using blog.Interfaces;
using blog.Mappers;
using blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers;

[Route("api/swallow")]
[ApiController]
public class SwallowController: ControllerBase
{
    private readonly ApplicationDBContext _context;
    private readonly ISwallowRepository _swallRepo;
    public SwallowController(ApplicationDBContext context, ISwallowRepository swallRepo)
    {
        _context = context;
        _swallRepo = swallRepo;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var swallows = await _swallRepo.GetAllAsync();
        var swallowsDto = swallows.Select(s => s.ToSwallowDto());
        return Ok(swallowsDto);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var swallow = await _swallRepo.GetByIdAsync(id);
        if(swallow == null) return NotFound();
        return Ok(swallow.ToSwallowDetailDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateSwallowDto swallowModel)
    {
        var swallow = swallowModel.ToSwallowFromCreateSwallowDto();
        await _swallRepo.CreateAsync(swallow);
        return CreatedAtAction(nameof(GetById), new { id = swallow.Id }, swallow.ToSwallowDto());
    }

}