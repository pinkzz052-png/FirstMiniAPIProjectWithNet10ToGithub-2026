using CopyStackOverFlow_Version2.Model;
using System.ComponentModel.DataAnnotations;

namespace CopyStackOverFlow_Version2.Dto
{
    public record CreatePostRequest(
    PostType Type,
    [StringLength(250)] string? Title, // Yêu cầu logic (tuỳ thuộc Type) sẽ xử lý ở Service
    [Required, MinLength(30)] string Body,
    List<string> Tags,
    Guid? ParentId // Bắt buộc nếu Type là Answer
    );
}
