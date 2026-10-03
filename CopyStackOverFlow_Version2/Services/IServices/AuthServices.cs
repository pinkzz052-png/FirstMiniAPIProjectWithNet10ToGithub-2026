using CopyStackOverFlow_Version2.Dto;

namespace CopyStackOverFlow_Version2.Services.IServices
{
    public interface IAuthServices
    {
        Task<AuthResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken);
        Task<AuthResponse> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken);
    }
}
