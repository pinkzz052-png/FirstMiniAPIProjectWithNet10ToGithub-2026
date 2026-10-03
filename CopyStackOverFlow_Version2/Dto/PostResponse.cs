using CopyStackOverFlow_Version2.Model;

namespace CopyStackOverFlow_Version2.Dto
{
    public record PostResponse(
    Guid Id,
    PostType Type,
    string? Title,
    string Body,
    int Score,
    int ViewCount,
    int AnswerCount,
    bool IsAccepted,
    List<string> Tags,
    DateTimeOffset CreatedAt,
    DateTimeOffset? LastEditedAt,
    AuthorSummaryResponse Author // Nested record: Gói gọn thông tin tác giả vào bài viết
    );
}
