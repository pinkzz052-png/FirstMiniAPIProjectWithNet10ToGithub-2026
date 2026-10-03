using CopyStackOverFlow_Version2.Data;
using CopyStackOverFlow_Version2.Dto;
using CopyStackOverFlow_Version2.GlobalExceptionHandler;
using CopyStackOverFlow_Version2.Services.IServices;
using Mapster;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using CopyStackOverFlow_Version2.Model;

namespace CopyStackOverFlow_Version2.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly AppDbContext _context;
        private readonly ITokenJwtServices _tokenJwtServices;
        public AuthServices(AppDbContext context, ITokenJwtServices tokenJwtServices)
        {
            _context = context;
            _tokenJwtServices = tokenJwtServices;
        }
        public async Task<AuthResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken)
        {
            var userLogin = await _context.Users.FindAsync(request.Email) ?? throw new NotFoundException("Ten nguoi dung hoac mat khau khong hop le");

            var isTruePassword = BCrypt.Net.BCrypt.Verify(request.Password, userLogin.PasswordHash);
            if (!isTruePassword) throw new NotFoundException("Ten nguoi dung hoac mat khau khong hop le");

            var authResponse = new AuthResponse(
                _tokenJwtServices.GenerateNewJwtToken(userLogin.Id, userLogin.Email),
                userLogin.Adapt<ProfileUserResponse>());

            return authResponse;
        }
        public async Task<AuthResponse> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken)
        {
            bool isEmailExist = await _context.Users
            .AnyAsync(u => u.Email == request.Email, cancellationToken);
            if (isEmailExist) throw new InvalidOperationException("Email da ton tai");
            bool isDisplayNameExist = await _context.Users
            .AnyAsync(d => d.DisplayName == request.DisplayName, cancellationToken);
            if (isDisplayNameExist) throw new InvalidOperationException("Ten da ton tai");

            var user = request.Adapt<User>();
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);

            return new AuthResponse(
                _tokenJwtServices.GenerateNewJwtToken(user.Id, user.Email),
                user.Adapt<ProfileUserResponse>());
        }
    }
}
