using blog.Models;

namespace blog.Interfaces;

public interface ISwallowRepository
{
    Task<List<Swallow>> GetAllAsync();
    Task<Swallow> GetByIdAsync(int id);
    Task<Swallow> CreateAsync(Swallow swallowModel);
    

}