using blog.Data;
using blog.Dtos.Algorithm;
using blog.Mappers;
using blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace blog.Controllers;

[Route("api/algorithm")]
[ApiController]
public class AlgorithmController : ControllerBase
{
    private readonly ApplicationDBContext _context;
    public AlgorithmController(ApplicationDBContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var algorithms = await _context.Algorithms.ToListAsync();
        var algorithmDto = algorithms.Select(s=>s.ToAlgorithmDto());
        return Ok(algorithmDto);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var algorithm = await _context.Algorithms.FindAsync(id);
        if(algorithm == null) return NotFound();
        return Ok(algorithm.ToAlgorithmDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAlgorithmDto algorithmDto)
    {
        var algorithmModel = algorithmDto.ToAlgorithmFromCreateAlgorithmDto();
        await  _context.Algorithms.AddAsync(algorithmModel);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = algorithmModel.Id }, algorithmModel.ToAlgorithmDto());
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAlgorithmDto algorithmDto)
    {
        var algorithm = await _context.Algorithms.FirstOrDefaultAsync(x => x.Id == id);
        if(algorithm == null) return NotFound();
        algorithm.Desc = algorithmDto.Desc;
        algorithm.Content = algorithmDto.Content;
        await _context.SaveChangesAsync();
        return Ok(algorithm.ToAlgorithmDto());
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var algorithm = await _context.Algorithms.FirstOrDefaultAsync(x => x.Id == id);
        if(algorithm == null) return NotFound();
        _context.Remove(algorithm);
        _context.SaveChanges();
        return NoContent();
    }
}