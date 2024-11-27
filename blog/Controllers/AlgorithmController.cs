using blog.Data;
using blog.Dtos.Algorithm;
using blog.Interfaces;
using blog.Mappers;
using blog.Models;
using blog.Query;
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
    public async Task<IActionResult> GetAll([FromQuery] PaginationParams paginationParams)
    {
        var algorithms = await _algorithmRepo.GetAllAsync(paginationParams.PageNumber, paginationParams.PageSize);
        return Ok(algorithms);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var algorithm = await _algorithmRepo.GetByIdAsync(id);
        if(algorithm == null) return NotFound();
        return Ok(algorithm.ToAlgorithmDetailDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAlgorithmDto algorithmDto)
    {
        var  algorithm = await _algorithmRepo.CreateAsync(algorithmDto);
        if(algorithm == null) return BadRequest("Failed to create algorithm");
        return Ok(algorithm);
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