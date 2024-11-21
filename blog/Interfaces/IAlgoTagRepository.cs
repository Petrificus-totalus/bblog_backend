using blog.Models;

namespace blog.Interfaces;

public interface IAlgoTagRepository
{
    Task<List<AlgoTag>> GetAllAsync();
    
}