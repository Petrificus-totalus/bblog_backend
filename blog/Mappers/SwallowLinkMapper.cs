using blog.Dtos.Swallow;
using blog.Models;

namespace blog.Mappers;

public static class SwallowLinkMapper
{
    public static SwallowLinkDto ToSwallowLinkDto(this SwallowLink link)
    {
        return new SwallowLinkDto
        {
            Id = link.Id,
            Link = link.Link,
            SwallowId = link.SwallowId,
        };
    }
}