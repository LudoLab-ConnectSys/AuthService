using System;
using System.ComponentModel.DataAnnotations;

namespace AuthService.Models
{
    public class UsuarioRol
    {
        [Required] public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        [Required] public int RolId { get; set; }
        public Rol Rol { get; set; }

        public DateTime FechaAsignacion { get; set; } = DateTime.Now;

        public bool EstadoActivo { get; set; } = true;
    }
}