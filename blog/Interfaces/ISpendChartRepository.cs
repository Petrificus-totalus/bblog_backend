using blog.Dtos.SpendChart;

namespace blog.Interfaces;

public interface ISpendChartRepository
{
    Task<List<SpendChartDto>> GetAllAsync(string item);
}