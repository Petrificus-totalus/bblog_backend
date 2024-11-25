using blog.Dtos.Tag;
using blog.Models;

namespace blog.Mappers;

public static class TagMapper
{
    public static TagDto ToTagDto(this SpendTag spendTag)
    {
        return new TagDto
        {
            Id = spendTag.TagId,
            TagName = spendTag.Tag.TagName
        };
    }
}