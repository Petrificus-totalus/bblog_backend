using blog.Dtos;
using blog.Dtos.Swallow;
using blog.Models;

namespace blog.Interfaces;

public interface ISwallowRepository
{
    Task<PagedResultDto<SwallowDto>> GetAllAsync(int pageNumber, int pageSize);
    Task<Swallow> GetByIdAsync(int id);
    Task<Swallow> CreateAsync(Swallow swallowModel);

    Task<bool> SwallowExist(int id);
}