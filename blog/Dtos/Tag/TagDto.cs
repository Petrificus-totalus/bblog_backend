using System.ComponentModel.DataAnnotations;
using blog.Models;

namespace blog.Dtos.Tag;

public class TagDto
{
    [Key]
    public int Id { get; set; } // 主键

    [Required]
    [MaxLength(100)]
    public string TagName { get; set; } = string.Empty; // 标签名称
}