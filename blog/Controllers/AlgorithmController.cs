using blog.Data;
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
        var algorithms = _context.Algorithms.ToList();
        return Ok(algorithms);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var algorithm = _context.Algorithms.Find(id);
        if(algorithm == null) return NotFound();
        return Ok(algorithm);
    }
}