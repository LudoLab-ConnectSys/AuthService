namespace AuthService.Models
{
    public class LoginRequest
    {
        public string Identification { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
    }
}