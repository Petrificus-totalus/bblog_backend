using blog.Data;
using blog.Interfaces;
using blog.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace blog.Controllers;


[Route("api/algotag")]
[ApiController]
public class AlgoTagController: ControllerBase
{
    private readonly ApplicationDBContext _context;
    private readonly IAlgoTagRepository _algoTagRepo;

    public AlgoTagController(ApplicationDBContext context, IAlgoTagRepository algoTagRepo)
    {
        _context = context;
        _algoTagRepo = algoTagRepo;
    }
    [HttpGet]  
    public async Task<IActionResult> GetAll()
    {
        var tags = await _algoTagRepo.GetAllAsync();
        var tagDto = tags.Select(s=>s.ToAlgoTagDto());
        return Ok(tagDto);
    }

    
}