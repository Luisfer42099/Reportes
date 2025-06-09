using System.ComponentModel.DataAnnotations.Schema;

namespace Reportes.Models
{
    [Table("usuario")]
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
    }
}
