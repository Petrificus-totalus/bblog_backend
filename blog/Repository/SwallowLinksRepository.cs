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

    public async Task<SwallowLink> CreateAsync(SwallowLink link)
    {
        await _context.SwallowLinks.AddAsync(link);
        await _context.SaveChangesAsync();
        return link;
    }

    public async Task<SwallowLink?> DeleteAsync(int id)
    {
       var swallowLinkModel = await  _context.SwallowLinks.FirstOrDefaultAsync(x => x.Id == id);
       if(swallowLinkModel == null) return null;
       _context.SwallowLinks.Remove(swallowLinkModel);
       await _context.SaveChangesAsync();
       return swallowLinkModel;
    }
}