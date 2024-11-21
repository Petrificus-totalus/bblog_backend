using blog.Dtos.Algorithm;
using blog.Models;

namespace blog.Interfaces;

public interface IAlgorithmRepository
{
    Task<List<Algorithm>> GetAllAsync();
    Task<Algorithm?> GetByIdAsync(int id);  // FirstOrDefault can be NULL
    Task<Algorithm> CreateAsync(Algorithm algorithm);
    Task<Algorithm?> UpdateAsync(int id, UpdateAlgorithmDto algorithmDto);
    Task<Algorithm?> DeleteAsync(int id);
  
    
}