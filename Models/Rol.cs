using System.ComponentModel.DataAnnotations;

namespace AuthService.Models
{
    public class Rol
    {
        [Key] public int RolId { get; set; }

        [Required] [StringLength(255)] public string NombreRol { get; set; } = string.Empty;

        public bool EstadoActivo { get; set; } = true;
    }
}