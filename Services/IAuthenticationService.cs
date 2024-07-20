using AuthService.Models;

namespace AuthService.Services
{
    public interface IAuthenticationService
    {
        Task<LoginResponse?> Login(LoginRequest loginModel);
        Task<string> HashPassword(string password);
        Task<string> GenerateJwtToken(Usuario usuario, string role);
    }
}