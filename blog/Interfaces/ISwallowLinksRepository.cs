using blog.Models;

namespace blog.Interfaces;

public interface ISwallowLinksRepository
{
    Task<List<SwallowLink>> GetAllAsync();
    Task<SwallowLink> GetByIdAsync(int id);
}