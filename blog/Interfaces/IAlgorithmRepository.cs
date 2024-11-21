using blog.Models;

namespace blog.Interfaces;

public interface IAlgorithmRepository
{
    Task<List<Algorithm>> GetAllAsync();
  
    
}