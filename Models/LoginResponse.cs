namespace AuthService.Models
{
    public class LoginResponse
    {
        public string Token { get; set; } = string.Empty;
        public int? IdInstructor { get; set; }
        public int? IdEstudiante { get; set; }
        public int? IdUsuario { get; set; }
        public string? NombreUsuario { get; set; }
    }
}