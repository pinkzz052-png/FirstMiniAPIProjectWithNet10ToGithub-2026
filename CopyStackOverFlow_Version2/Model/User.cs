using System.ComponentModel.DataAnnotations;

namespace CopyStackOverFlow_Version2.Model
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string DisplayName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(254)]
        public string Email { get; set; } = null!;

        [Required]
        public string PasswordHash { get; set; } = null!;

        // Các thông tin giống StackOverflow
        public int Reputation { get; set; } = 1; // Điểm uy tín khởi đầu là 1
        public int UpVotes { get; set; } = 0;
        public int DownVotes { get; set; } = 0;
        public int Views { get; set; } = 0; // Lượt người khác xem profile

        [StringLength(2000)]
        public string? AboutMe { get; set; }

        [StringLength(100)]
        public string? Location { get; set; }

        [Url]
        [StringLength(200)]
        public string? WebsiteUrl { get; set; }

        [Url]
        public string? ProfileImageUrl { get; set; }

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? LastAccessDate { get; set; }

        // Navigation Property: Danh sách bài viết của user này
        public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}

