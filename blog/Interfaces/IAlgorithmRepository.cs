using blog.Dtos;
using blog.Dtos.Algorithm;
using blog.Models;

namespace blog.Interfaces;

public interface IAlgorithmRepository
{
    Task<PagedResultDto<AlgorithmDto>> GetAllAsync(int pageNumber, int pageSize);
    Task<Algorithm?> GetByIdAsync(int id);  // FirstOrDefault can be NULL
    Task<Algorithm> CreateAsync(Algorithm algorithm);
    Task<Algorithm?> UpdateAsync(int id, UpdateAlgorithmDto algorithmDto);
    Task<Algorithm?> DeleteAsync(int id);
  
    
}