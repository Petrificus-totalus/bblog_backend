using blog.Dtos;
using blog.Dtos.Spend;
using blog.Models;

namespace blog.Interfaces;

public interface ISpendRepository
{
    public Task<PagedResultDto<GroupedSpendDto>> GetAllAsync(int pageNumber, int pageSize);
    public Task<Spend> CreateAsync(CreateSpendDto createSpendDto);
    public Task<SpendDetailDto> GetByIdAsync(int id);
}