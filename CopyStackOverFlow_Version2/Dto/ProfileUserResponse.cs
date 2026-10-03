namespace CopyStackOverFlow_Version2.Dto
{
     public record ProfileUserResponse(
     Guid Id,
     string DisplayName,
     int Reputation,
     string? ProfileImageUrl,
     string? Location,
     string? AboutMe,
     string? WebsiteUrl,
     int Views,
     DateTimeOffset CreatedAt,
     DateTimeOffset? LastAccessDate
     );
}
