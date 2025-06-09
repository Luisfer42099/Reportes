using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Reportes.Data;

namespace Reportes.Controllers
{
    public class LoginController : Controller
    {
        private readonly BDContext _context;

        public LoginController(BDContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string nombreUsuario, string contrasena)
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.NombreUsuario == nombreUsuario && u.Contrasena == contrasena);

            if (usuario != null)
            {
                // Autenticado correctamente
                return RedirectToAction("Index", "Persona"); // o donde quieras ir después
            }

            ViewBag.Error = "Usuario o contraseña incorrectos.";
            return View();
        }
    }
}
