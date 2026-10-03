namespace CopyStackOverFlow_Version2.Services.IServices
{
    public interface ICurrentUserServices
    {
        Guid? UserId { get; }
        string? UserEmail { get; }
        bool IsAuthenticated { get; }
        Guid GetRequiredUserId();
    }
}
