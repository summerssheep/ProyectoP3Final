
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGBLWEB.Data;
using SGBLWEB.Models;

namespace SGBLWEB.Controllers
{
    public class IUsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IUsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IUsuarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        // GET: IUsuarios/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iUsuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iUsuario == null)
            {
                return NotFound();
            }

            return View(iUsuario);
        }

        // GET: IUsuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Correo,Contrasena,Matricula,TipoUsuario")] IUsuario iUsuario)
        {
            if (ModelState.IsValid)
            {
                iUsuario.Id = Guid.NewGuid();
                _context.Add(iUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iUsuario);
        }

        // GET: IUsuarios/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iUsuario = await _context.Usuarios.FindAsync(id);
            if (iUsuario == null)
            {
                return NotFound();
            }
            return View(iUsuario);
        }

        // POST: IUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nombre,Apellido,Correo,Contrasena,Matricula,TipoUsuario")] IUsuario iUsuario)
        {
            if (id != iUsuario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IUsuarioExists(iUsuario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(iUsuario);
        }

        // GET: IUsuarios/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iUsuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iUsuario == null)
            {
                return NotFound();
            }

            return View(iUsuario);
        }

        // POST: IUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var iUsuario = await _context.Usuarios.FindAsync(id);
            if (iUsuario != null)
            {
                _context.Usuarios.Remove(iUsuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IUsuarioExists(Guid id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
