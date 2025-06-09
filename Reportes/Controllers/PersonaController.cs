using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reportes.Data;
using Reportes.Models;

namespace Reportes.Controllers
{
    public class PersonaController : Controller
    {
        private readonly BDContext _context;

        public PersonaController(BDContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var personas = await _context.Personas.ToListAsync();
            return View(personas);
        }

        // GET: Persona/Editar/5
        public async Task<IActionResult> Editar(int id)
        {
            var persona = await _context.Personas.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }
            return View(persona);
        }

        // POST: Persona/Editar/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Persona persona)
        {
            if (id != persona.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(persona);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    return BadRequest("No se pudo guardar los cambios.");
                }
            }
            return View(persona);
        }

    }
}
