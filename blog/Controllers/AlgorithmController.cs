using blog.Data;
using blog.Dtos.Algorithm;
using blog.Mappers;
using blog.Models;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult GetAll()
    {
        var algorithms = _context.Algorithms.ToList().Select(s=>s.ToAlgorithmDto());
        return Ok(algorithms);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var algorithm = _context.Algorithms.Find(id);
        if(algorithm == null) return NotFound();
        return Ok(algorithm.ToAlgorithmDto());
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateAlgorithmDto algorithmDto)
    {
        var algorithmModel = algorithmDto.ToAlgorithmFromCreateAlgorithmDto();
        _context.Algorithms.Add(algorithmModel);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = algorithmModel.Id }, algorithmModel.ToAlgorithmDto());
    }

    [HttpPut]
    [Route("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateAlgorithmDto algorithmDto)
    {
        var algorithm = _context.Algorithms.FirstOrDefault(x => x.Id == id);
        if(algorithm == null) return NotFound();
        algorithm.Desc = algorithmDto.Desc;
        algorithm.Content = algorithmDto.Content;
        _context.SaveChanges();
        return Ok(algorithm.ToAlgorithmDto());
    }
    
    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var algorithm = _context.Algorithms.FirstOrDefault(x => x.Id == id);
        if(algorithm == null) return NotFound();
        _context.Remove(algorithm);
        _context.SaveChanges();
        return NoContent();
    }
}