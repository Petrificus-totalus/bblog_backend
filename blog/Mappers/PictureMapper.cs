using blog.Dtos.Picture;
using blog.Models;

namespace blog.Mappers;

public static class PictureMapper
{
    public static PictureDto ToPictureDto(this Picture picture)
    {
        return new PictureDto
        {
            Id = picture.Id,
            Link = picture.Link,
        };
    }
}