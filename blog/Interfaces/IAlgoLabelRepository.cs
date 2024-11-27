
using blog.Models;

namespace blog.Interfaces;

public interface IAlgoLabelRepository
{
    Task<List<Label>> GetAllAsync();
}