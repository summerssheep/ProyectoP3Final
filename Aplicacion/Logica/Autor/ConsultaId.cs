using MediatR;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Accesodatos.Context;

namespace Aplicación.Logica.Autor
{
    public class ConsultaId : Autores
    {
        public class AutorDtoId
        {

            public string? nombre { get; set; }
            public string? apellido { get; set; }
            public string? pais { get; set; }
            public string? descripcion { get; set; }
        }

        public class AutorporId : IRequest<AutorDtoId>
        {
            public Guid Id { get; set; }
        }

        public class Manejador : IRequestHandler<AutorporId, AutorDtoId>
        {
            private readonly ProyectoContext _context;
            public Manejador(ProyectoContext context)
            {
                _context = context;
            }
            public async Task<AutorDtoId> Handle(AutorporId request, CancellationToken cancellationToken)
            {
                var autor = await _context.Autores
                    .Where(a => a.id == request.Id)
                    .Select(a => new AutorDtoId
                    {
                        nombre = a.nombre,
                        apellido = a.apellido,
                        pais = a.pais,
                        descripcion = a.descripcion
                    })
                    .FirstOrDefaultAsync();

                return autor ?? new AutorDtoId(); // Devuelve una instancia nueva si autor es null
            }
        }

    }

}