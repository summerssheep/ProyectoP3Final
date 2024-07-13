using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accesodatos.Tablas
{
    public class Editorial
    {
        public Guid Id { get; set; }
        public string ? nombre { get; set; }
        public string ? Direccion { get; set; }
        public string ? Telefono { get; set; }
        public string?  Email { get; set; }

        // Propiedad de navegación para la relación con los libros
        public ICollection<Libros> ? Libros { get; set; }
    }
}
