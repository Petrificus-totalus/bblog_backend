using blog.Data;
using blog.Interfaces;
using blog.Models;
using Microsoft.EntityFrameworkCore;

namespace blog.Repository;

public class SwallowRepository: ISwallowRepository
{

    private readonly ApplicationDBContext _context;
    public SwallowRepository(ApplicationDBContext dbContext)
    {
        _context = dbContext;
    }
    public async Task<List<Swallow>> GetAllAsync()
    {
        return await _context.Swallow.Include(c=>c.Links).ToListAsync();
    }

    public async Task<Swallow> GetByIdAsync(int id)
    {
        return await _context.Swallow.Include(c=>c.Links).FirstOrDefaultAsync(x=>x.Id == id);
    }

    public async Task<Swallow> CreateAsync(Swallow swallowModel)
    {
        await _context.Swallow.AddAsync(swallowModel);
        await _context.SaveChangesAsync();
        return swallowModel;
    }

    public Task<bool> SwallowExist(int id)
    {
       return _context.Swallow.AnyAsync(s=>s.Id == id);
    }
}