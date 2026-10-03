using System.ComponentModel.DataAnnotations;

namespace CopyStackOverFlow_Version2.Dto
{
    public record LoginRequest(
    [Required, EmailAddress] string Email,
    [Required] string Password
    );
}
