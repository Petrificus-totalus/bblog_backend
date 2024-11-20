namespace blog.Models;

public class AlgoTag
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int? AlgorithmId { get; set; }
    // Navigation Property
    public Algorithm? Algorithm { get; set; }
}