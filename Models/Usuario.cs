using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthService.Models
{
    public class Usuario
    {
        [Key] [Column("id_usuario")] public int IdUsuario { get; set; }

        [StringLength(20)]
        [Column("cedula_usuario")]
        public string CedulaUsuario { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        [Column("HashContrasena")]
        public string HashContrasena { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        [Column("nombre_usuario")]
        public string NombreUsuario { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        [Column("apellidos_usuario")]
        public string ApellidosUsuario { get; set; } = string.Empty;

        [Column("estadoActivo")] public bool EstadoActivo { get; set; } = true;
    }
}