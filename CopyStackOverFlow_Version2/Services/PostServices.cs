using CopyStackOverFlow_Version2.Data;
using CopyStackOverFlow_Version2.Dto;
using CopyStackOverFlow_Version2.Services.IServices;
using Mapster;
using CopyStackOverFlow_Version2.Model;

namespace CopyStackOverFlow_Version2.Services
{
    public class PostServices : IPostServices
    {
        private readonly AppDbContext _context;
        public PostServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PostResponse> CreatePostAsync(CreatePostRequest request, CancellationToken cancellationToken)
        {
            var post = request.Adapt<Post>();
            _context.Posts.Add(post);
            await _context.SaveChangesAsync(cancellationToken);
            return post.Adapt<PostResponse>();
        }
        public async Task<PostResponse> GetPostByIdAsync(int postId, CancellationToken cancellationToken)
        {
            var post = await _context.Posts.FindAsync(postId) ?? throw new KeyNotFoundException("Post not found");
            return post.Adapt<PostResponse>();
        }
        public async Task<PostResponse> UpdatePostAsync(int postId, UpdatePostRequest request, CancellationToken cancellationToken)
        {
            var post = await _context.Posts.FindAsync(postId) ?? throw new KeyNotFoundException("Post khong ton tai");
            post.Title = request.Title ?? post.Title;
            post.Body = request.Body;
            await _context.SaveChangesAsync(cancellationToken);
            return post.Adapt<PostResponse>();
        }
        public async Task DeletePostAsync(int postId, CancellationToken cancellationToken)
        {
            var post = await _context.Posts.FindAsync(postId) ?? throw new KeyNotFoundException("Post khong ton tai");
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
