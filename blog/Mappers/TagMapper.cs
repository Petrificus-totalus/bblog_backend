using blog.Dtos.Tag;
using blog.Models;

namespace blog.Mappers;

public static class TagMapper
{
    public static TagDto FromSpendTagToTagDto(this SpendTag spendTag)
    {
        return new TagDto
        {
            Id = spendTag.TagId,
            TagName = spendTag.Tag.TagName
        };
    }
    public static TagDto ToTagDto(this Tag tag)
    {
        return new TagDto
        {
            Id = tag.Id,
            TagName = tag.TagName
        };
    }
}