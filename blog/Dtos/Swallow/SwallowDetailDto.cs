namespace blog.Dtos.Swallow;

public class SwallowDetailDto
{
    public int Id { get; set; } 
    public string Restaurant { get; set; } = string.Empty; 
    public decimal Rating { get; set; } 
    public string? Review { get; set; }
    public string? Summary { get; set; } 
    public string? CoverImage { get; set; } 
    public DateTime CreateTime { get; set; } = DateTime.Now; 
}