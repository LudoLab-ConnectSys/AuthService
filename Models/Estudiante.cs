using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthService.Models
{
    public class Estudiante
    {
        [Key] [Column("id_estudiante")] public int IdEstudiante { get; set; }

        [Required] [Column("id_usuario")] public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")] public Usuario Usuario { get; set; }
    }
}