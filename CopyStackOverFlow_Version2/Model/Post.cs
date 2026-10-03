using CopyStackOverFlow_Version2.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CopyStackOverFlow_Version2.Model
{
    public enum PostType
    {
        Question = 1,
        Answer = 2,
        Article = 3
    }
    public class Post
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public PostType Type { get; set; }

        // Title chỉ bắt buộc nếu là Câu hỏi (Question), Câu trả lời (Answer) có thể null
        [StringLength(250)]
        public string? Title { get; set; }

        [Required]
        public string Body { get; set; } = null!; // Chứa nội dung HTML hoặc Markdown

        // Chỉ số đặc trưng của StackOverflow
        public int Score { get; set; } = 0; // Upvotes - Downvotes
        public int ViewCount { get; set; } = 0;
        public int AnswerCount { get; set; } = 0; // Nếu là câu hỏi thì đếm số câu trả lời

        // Quản lý trạng thái duyệt
        public bool IsAccepted { get; set; } = false; // Dành cho Answer (Được chủ thớt tick xanh)
        public Guid? AcceptedAnswerId { get; set; }   // Dành cho Question (Trỏ tới ID của Answer được chọn)

        // Từ Entity Framework 8+, có thể lưu trực tiếp List<string> thành kiểu mảng JSON trong DB
        public List<string> Tags { get; set; } = new List<string>();

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset? LastEditedAt { get; set; }

        // Navigation Properties
        [Required]
        public Guid AuthorId { get; set; }

        [ForeignKey(nameof(AuthorId))]
        public virtual User Author { get; set; } = null!;

        // Tự tham chiếu: Nếu đây là Câu trả lời, nó thuộc về Câu hỏi nào?
        public Guid? ParentId { get; set; }

        [ForeignKey(nameof(ParentId))]
        public virtual Post? ParentPost { get; set; }
    }
}