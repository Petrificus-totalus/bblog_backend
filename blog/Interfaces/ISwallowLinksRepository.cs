using blog.Models;

namespace blog.Interfaces;

public interface ISwallowLinksRepository
{
    Task<List<SwallowLink>> GetAllAsync();
    Task<SwallowLink?> GetByIdAsync(int id);
    
    Task<SwallowLink> CreateAsync(SwallowLink link);
    Task<SwallowLink?> DeleteAsync(int id);
    Task<SwallowLink> UpdateAsync(int swallowLinkId, SwallowLink link);
    
    
}