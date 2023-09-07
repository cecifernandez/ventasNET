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

        public IActionResult EditarUsuario(Usuario user)
        {
            UsuarioRepo userRepo = new UsuarioRepo();
            
            userRepo.ModificarUsuario(user);

            
            return RedirectToAction("Inicio");
        }

        public IActionResult GuardarUser(Usuario user)
        {
            UsuarioRepo userRepo = new UsuarioRepo();
            bool existe = false;

            Usuario existeUser = new Usuario();

            existe = userRepo.VerificarUsuario(user);

            if (existe)
            {
                userRepo.ModificarUsuario(user);
            }
            else
            {
                user.Estado = true;

                Listados.ListaUsuario.Add(user);
            }


            return RedirectToAction("Inicio");
        }

        public IActionResult AgregarProv(Proveedor prov)
        {
            return View();
        }
        public IActionResult VerUsuario() 
        { 
            return View(); 
        }

    }
}
