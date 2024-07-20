using AuthService.Data;
using AuthService.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly AuthDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthenticationService(AuthDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<LoginResponse?> Login(LoginRequest loginModel)
        {
            // Buscar el usuario por cédula o pasaporte
            var usuario =
                await _context.Usuario.SingleOrDefaultAsync(u => u.CedulaUsuario == loginModel.Identification);

            if (usuario == null || !VerifyPassword(loginModel.Password, usuario.HashContrasena))
            {
                return null;
            }

            // Verificar que el usuario tiene el rol especificado
            var userRole = await _context.UsuarioRol
                .Include(ur => ur.Rol)
                .SingleOrDefaultAsync(ur => ur.UsuarioId == usuario.IdUsuario && ur.Rol.NombreRol == loginModel.Rol);

            if (userRole == null)
            {
                return null;
            }

            var token = await GenerateJwtToken(usuario, loginModel.Rol);

            return new LoginResponse { Token = token };
        }

        public async Task<string> HashPassword(string password)
        {
            return await Task.Run(() => BCrypt.Net.BCrypt.HashPassword(password));
        }

        public async Task<string> GenerateJwtToken(Usuario usuario, string role)
        {
            var claims = new[]
            {
                new Claim("IdUsuario", usuario.IdUsuario.ToString()),
                new Claim(ClaimTypes.Name, usuario.NombreUsuario),
                new Claim(ClaimTypes.Role, role),
            };

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: creds);

            return await Task.Run(() => new JwtSecurityTokenHandler().WriteToken(token));
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}