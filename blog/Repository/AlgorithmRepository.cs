using blog.Data;
using blog.Interfaces;
using blog.Models;
using Microsoft.EntityFrameworkCore;

namespace blog.Repository;

public class AlgorithmRepository: IAlgorithmRepository
{
    
    private readonly ApplicationDBContext _context;
    public AlgorithmRepository(ApplicationDBContext DBContext)
    {
        _context = DBContext;
    }
    
    public Task<List<Algorithm>> GetAllAsync()
    {
        return _context.Algorithms.ToListAsync();
    }

    
}