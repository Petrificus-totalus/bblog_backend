using blog.Dtos.Swallow;
using blog.Models;

namespace blog.Mappers;

public static class SwallowMapper
{
    public static SwallowDto ToSwallowDto(this Swallow swallowModel)
    {
        return new SwallowDto
        {
            Id = swallowModel.Id,
            Rating = swallowModel.Rating,
            Restaurant = swallowModel.Restaurant,
            Summary = swallowModel.Summary,
            CoverImage = swallowModel.CoverImage,
            CreateTime = swallowModel.CreateTime,
            Links = swallowModel.Links.Select(c=>c.ToSwallowLinkDto()).ToList()
        };
    }
    public static SwallowDetailDto ToSwallowDetailDto(this Swallow swallowModel)
    {
        return new SwallowDetailDto
        {
            Id = swallowModel.Id,
            Rating = swallowModel.Rating,
            Restaurant = swallowModel.Restaurant,
            Summary = swallowModel.Summary,
            Review = swallowModel.Review,
            CoverImage = swallowModel.CoverImage,
            CreateTime = swallowModel.CreateTime,
        };
    }
    public static Swallow ToSwallowFromCreateSwallowDto(this CreateSwallowDto swallowModel)
    {
        return new Swallow
        {
            Rating = swallowModel.Rating,
            Restaurant = swallowModel.Restaurant,
            Summary = swallowModel.Summary,
            Review = swallowModel.Review,
            CoverImage = swallowModel.CoverImage,
            CreateTime = swallowModel.CreateTime,
        };
    }
}