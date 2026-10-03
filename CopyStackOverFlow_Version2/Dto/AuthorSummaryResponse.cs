namespace CopyStackOverFlow_Version2.Dto
{
    public record AuthorSummaryResponse(
    Guid Id,
    string DisplayName,
    int Reputation,
    string? ProfileImageUrl
    );
}
