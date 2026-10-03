using System.ComponentModel.DataAnnotations;

namespace CopyStackOverFlow_Version2.Dto
{
    public record RegisterRequest(

    [Required, StringLength(50, MinimumLength = 3,ErrorMessage = "Tên phải từ 3 ký tự trở lên")]
    string DisplayName,

    [Required, EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ")]
    string Email,

    [property: Required, StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6 ký tự trở lên")] 
    string Password,

    [property: Required, Compare("PasswordHash", ErrorMessage = "Mật khẩu Không khớp")]
    string ConfirmPassword
    );
}
