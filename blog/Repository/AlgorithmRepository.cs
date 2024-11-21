using blog.Data;
using blog.Dtos.Algorithm;
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
    
    public async Task<List<Algorithm>> GetAllAsync()
    {
        return await _context.Algorithms.ToListAsync();
    }

    public async Task<Algorithm?> GetByIdAsync(int id)
    {
        return await _context.Algorithms.FindAsync(id);
    }

    public async Task<Algorithm> CreateAsync(Algorithm algorithmModel)
    {
        await  _context.Algorithms.AddAsync(algorithmModel);
        await _context.SaveChangesAsync();
        return algorithmModel;
    }

    public async Task<Algorithm?> UpdateAsync(int id, UpdateAlgorithmDto algorithmDto)
    {
        var algorithm = await _context.Algorithms.FirstOrDefaultAsync(x=>x.Id == id);
        if(algorithm == null) return null;
        algorithm.Desc = algorithmDto.Desc;
        algorithm.Content = algorithmDto.Content;
        await _context.SaveChangesAsync();
        return algorithm;
    }

    public async Task<Algorithm?> DeleteAsync(int id)
    {
        var algorithm = await _context.Algorithms.FirstOrDefaultAsync(x=>x.Id == id);
        if(algorithm == null) return null;
        _context.Algorithms.Remove(algorithm);
        await _context.SaveChangesAsync();
        return algorithm;
    }
}