using blog.Dtos.Spend;
using blog.Models;

namespace blog.Mappers;

public static class SpendMapper
{
    public static Spend ToSpendFromCreateSpendDto(this CreateSpendDto createSpendDto)
    {
        return new Spend
        {
            Description = createSpendDto.Description,
            Price = createSpendDto.Price,
            Location = createSpendDto.Location,
            Title = createSpendDto.Title,
            CreateTime = createSpendDto.CreateTime.Date,
        };
    }
    public static SpendDto ToSpendDto(this Spend spendModel)
    {
        return new SpendDto
        {
            Id = spendModel.Id,
            Price = spendModel.Price,
            Location = spendModel.Location,
            Title = spendModel.Title,
            CreateTime = spendModel.CreateTime.Date,
            Tags = spendModel.SpendTags.Select(c=>c.ToTagDto()).ToList(),
            HasDetail = !string.IsNullOrEmpty(spendModel.Description) || spendModel.Pictures.Any() // 判断条件
        };
    }
}