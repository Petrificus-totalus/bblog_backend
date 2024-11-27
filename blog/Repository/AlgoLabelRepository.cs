using blog.Data;
using blog.Interfaces;
using blog.Models;
using Microsoft.EntityFrameworkCore;

namespace blog.Repository;

public class AlgoLabelRepository: IAlgoLabelRepository
{
    private readonly ApplicationDBContext _context;
    public AlgoLabelRepository(ApplicationDBContext DBContext)
    {
        _context = DBContext;
    }
    public async Task<List<Label>> GetAllAsync()
    {
        return await _context.Labels.ToListAsync();
    }
}