using Microsoft.AspNetCore.Http;
using CopyStackOverFlow_Version2.Services.IServices;
namespace CopyStackOverFlow_Version2.Services
{
    public class CurrentUserServices : ICurrentUserServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CurrentUserServices(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public Guid? UserId => GetUserIdFromClaims();
        public string? UserEmail => GetUserEmailFromClaims();
        public bool IsAuthenticated => _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
        public Guid GetRequiredUserId()
        {
            var userId = UserId;
            if (userId == null)
            {
                throw new UnauthorizedAccessException("User is not authenticated.");
            }
            return userId.Value;
        }
        private Guid? GetUserIdFromClaims()
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst("sub");
            if (userIdClaim != null && Guid.TryParse(userIdClaim.Value, out var userId))
            {
                return userId;
            }
            return null;
        }
        private string? GetUserEmailFromClaims()
        {
            return _httpContextAccessor.HttpContext?.User?.FindFirst("email")?.Value;
        }
    }
}
