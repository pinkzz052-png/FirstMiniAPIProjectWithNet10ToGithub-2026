using CopyStackOverFlow_Version2.Dto;

namespace CopyStackOverFlow_Version2.Services.IServices
{
    public interface IUserServices
    {
        Task<ProfileUserResponse> GetUserByIdAsync(int userId, CancellationToken cancellationToken);
    }
}
