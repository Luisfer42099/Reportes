using System.ComponentModel.DataAnnotations.Schema;

namespace Reportes.Models
{
    [Table("persona")]
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public int IIDSexo { get; set; }
        public string Correo { get; set; }
        public string TelefonoOCelular1 { get; set; }
        public int IIDTipoDocumento { get; set; }
        public string NumeroIdentificacion { get; set; }
    }
}
