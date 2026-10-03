using System.ComponentModel.DataAnnotations;

namespace CopyStackOverFlow_Version2.Dto
{
    public record UpdatePostRequest(
    [StringLength(250)] string? Title,
    [Required, MinLength(30)] string Body
    );
}
