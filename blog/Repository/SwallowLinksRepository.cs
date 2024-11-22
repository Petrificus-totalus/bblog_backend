using blog.Data;
using blog.Interfaces;
using blog.Models;
using Microsoft.EntityFrameworkCore;

namespace blog.Repository;

public class SwallowLinksRepository: ISwallowLinksRepository
{
    private readonly ApplicationDBContext _context;
    public SwallowLinksRepository(ApplicationDBContext context)
    {
        _context = context;
    }
    public async Task<List<SwallowLink>> GetAllAsync()
    {
        return await _context.SwallowLinks.ToListAsync();
    }

    public async Task<SwallowLink> GetByIdAsync(int id)
    {
        return await _context.SwallowLinks.FindAsync(id);
    }
}