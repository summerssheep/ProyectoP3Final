using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Accesodatos.Tablas;
using Accesodatos.Context;

namespace Aplicación.Logica.Autor
{
    public class Consulta
    {
        public class ListaAutores : IRequest<List<Accesodatos.Tablas.Autores>> { }

        public class Manejador : IRequestHandler<ListaAutores, List<Accesodatos.Tablas.Autores>>
        {
            private readonly ProyectoContext _context;

            public Manejador(ProyectoContext context)
            {
                _context = context;
            }

            public async Task<List<Accesodatos.Tablas.Autores>> Handle(ListaAutores request, CancellationToken cancellationToken)
            {
                var autores = await _context.Autores.ToListAsync();
                return autores;
            }
        }
    }
}
