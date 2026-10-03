using CopyStackOverFlow_Version2.Dto;

namespace CopyStackOverFlow_Version2.Services.IServices
{
    public interface IPostServices
    {
        Task<PostResponse> CreatePostAsync(CreatePostRequest request, CancellationToken cancellationToken);
        Task<PostResponse> GetPostByIdAsync(int postId, CancellationToken cancellationToken);
        Task<PostResponse> UpdatePostAsync(int postId, UpdatePostRequest request, CancellationToken cancellationToken);
        Task DeletePostAsync(int postId, CancellationToken cancellationToken);
    }
}
