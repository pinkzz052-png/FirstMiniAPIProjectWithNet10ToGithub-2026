using System.ComponentModel.DataAnnotations;

namespace CopyStackOverFlow_Version2.Dto
{
    public record UpdateUserRequest(
    [StringLength(50, MinimumLength = 3)] string DisplayName,
    [StringLength(100)] string? Location,
    [StringLength(2000)] string? AboutMe,
    [Url] string? WebsiteUrl,
    [Url] string? ProfileImageUrl
    );
}
