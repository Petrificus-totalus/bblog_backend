using blog.Data;
using blog.Interfaces;
using blog.Models;
using Microsoft.EntityFrameworkCore;

namespace blog.Repository;

public class AlgoTagRepository: IAlgoTagRepository
{
    private readonly ApplicationDBContext _context;
    public AlgoTagRepository(ApplicationDBContext DBContext)
    {
        _context = DBContext;
    }
    public async Task<List<AlgoTag>> GetAllAsync()
    {
        return await _context.AlgoTags.ToListAsync();
    }
}