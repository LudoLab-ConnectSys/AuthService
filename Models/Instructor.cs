using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuthService.Models
{
    public class Instructor
    {
        [Key] [Column("id_instructor")] public int IdInstructor { get; set; }

        [Required] [Column("id_usuario")] public int IdUsuario { get; set; }

        [ForeignKey("IdUsuario")] public Usuario Usuario { get; set; }
    }
}