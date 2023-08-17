using Microsoft.AspNetCore.Mvc;
using VentaNET.Models;
using VentaNET.Repositories;

namespace VentaNET.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Inicio()
        {
            return View();
        }

        public IActionResult Verificar(Usuario user)
        {
            UsuarioRepo userRepo = new UsuarioRepo();
            if (userRepo.VerificarUsuario(user))
            {
                return RedirectToAction("Listado", "Cliente");
            }
            else
            {
                return View();
            }

        }
    }
}
