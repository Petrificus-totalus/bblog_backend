using blog.Data;
using blog.Dtos.Algorithm;
using blog.Interfaces;
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
    private readonly IAlgorithmRepository _algorithmRepo;

    public AlgorithmController(ApplicationDBContext context, IAlgorithmRepository algorithmRepo)
    {
        _context = context;
        _algorithmRepo = algorithmRepo;
    }

    [HttpGet]  
    public async Task<IActionResult> GetAll()
    {
        var algorithms = await _algorithmRepo.GetAllAsync();
        var algorithmDto = algorithms.Select(s=>s.ToAlgorithmDto());
        return Ok(algorithmDto);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var algorithm = await _algorithmRepo.GetByIdAsync(id);
        if(algorithm == null) return NotFound();
        return Ok(algorithm.ToAlgorithmDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAlgorithmDto algorithmDto)
    {
        var algorithmModel = algorithmDto.ToAlgorithmFromCreateAlgorithmDto();
        await _algorithmRepo.CreateAsync(algorithmModel);
        return CreatedAtAction(nameof(GetById), new { id = algorithmModel.Id }, algorithmModel.ToAlgorithmDto());
    }

    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateAlgorithmDto algorithmDto)
    {
        var algorithm = await _algorithmRepo.UpdateAsync(id, algorithmDto);
        if(algorithm == null) return NotFound();
        return Ok(algorithm.ToAlgorithmDto());
    }
    
    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var algorithm = await _algorithmRepo.DeleteAsync(id);
        if(algorithm == null) return NotFound();
        return NoContent();
    }
}