using blog.Dtos.AlgoTag;
using blog.Dtos.Tag;

namespace blog.Dtos.Algorithm;

public class AlgorithmDto
{
    public int Id { get; set; }
    public string Desc { get; set; } = string.Empty;
    public List<AlgoLabelDto> Labels { get; set; } = new List<AlgoLabelDto>();
}