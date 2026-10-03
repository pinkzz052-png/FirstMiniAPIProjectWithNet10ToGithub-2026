using Microsoft.AspNetCore.Http;

namespace CopyStackOverFlow_Version2.GlobalExceptionHandler
{

    // 1. Lớp Exception gốc (Base) cho toàn bộ ứng dụng
    public abstract class BaseException : Exception
    {
        public int StatusCode { get; }
        public string Title { get; }
        public IDictionary<string, string[]>? Errors { get; }

        protected BaseException(
            string message,
            int statusCode = StatusCodes.Status500InternalServerError,
            string title = "Lỗi hệ thống",
            IDictionary<string, string[]>? errors = null)
            : base(message)
        {
            StatusCode = statusCode;
            Title = title;
            Errors = errors;
        }
    }

    // 2. Lỗi 404 - Không tìm thấy dữ liệu
    public class NotFoundException : BaseException
    {
        public NotFoundException(string message, string title = "Resource Not Found")
            : base(message, StatusCodes.Status404NotFound, title) { }
    }

    // 3. Lỗi 400 - Thao tác / Yêu cầu không hợp lệ
    public class BadRequestException : BaseException
    {
        public BadRequestException(string message, string title = "Bad Request")
            : base(message, StatusCodes.Status400BadRequest, title) { }
    }

    // 4. Lỗi 401 - Chưa đăng nhập / Token không hợp lệ
    public class UnauthorizedException : BaseException
    {
        public UnauthorizedException(string message = "Bạn cần đăng nhập để thực hiện thao tác này", string title = "Unauthorized")
            : base(message, StatusCodes.Status401Unauthorized, title) { }
    }

    // 5. Lỗi 403 - Không có quyền truy cập
    public class ForbiddenException : BaseException
    {
        public ForbiddenException(string message = "Bạn không có quyền truy cập tài nguyên này", string title = "Forbidden")
            : base(message, StatusCodes.Status403Forbidden, title) { }
    }

    // 6. Lỗi 400 - Lỗi Validate dữ liệu đầu vào (Nhiều trường lỗi cùng lúc)
    public class ValidationException : BaseException
    {
        public ValidationException(IDictionary<string, string[]> errors, string message = "Dữ liệu đầu vào không hợp lệ")
            : base(message, StatusCodes.Status400BadRequest, "Validation Error", errors) { }
    }
}