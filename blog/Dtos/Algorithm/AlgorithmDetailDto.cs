using blog.Dtos.AlgoTag;
using blog.Models;

namespace blog.Dtos.Algorithm;

public class AlgorithmDetailDto
{
    public int Id { get; set; }
    public string Desc { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public List<AlgoLabelDto> AlgoLabels { get; set; } = new List<AlgoLabelDto>();
}