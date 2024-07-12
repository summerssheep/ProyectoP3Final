using System.ComponentModel.DataAnnotations;

namespace SGBLWEB.Models
{
    public class IUsuario
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(64)]
        public string ? Nombre { get; set; }
        [Required]
        [MaxLength(64)]
        public string? Apellido { get; set; }
        [Required]
        [MaxLength(100)]
        public string ? Correo { get; set; }
        [Required]
        [MaxLength(32)]
        public string ? Contrasena { get; set; }
        [Required]
        public int Matricula { get; set; }
        [Required]
        [MaxLength(18)]
        public string ? TipoUsuario { get; set; }
    }
}
