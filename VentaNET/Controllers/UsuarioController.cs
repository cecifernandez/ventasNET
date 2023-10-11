using Microsoft.AspNetCore.Mvc;
using VentaNET.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.Interfaces;
using VentasNet.Infra.Repositories;

namespace VentaNET.Controllers
{
    public class UsuarioController : Controller
    {
        IUsuarioRepo usuarioRepo;

        public UsuarioController(IUsuarioRepo _usuarioRepo)
        {
            usuarioRepo = _usuarioRepo;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Inicio()
        {
            return View();
        }

        public IActionResult Verificar(UsuarioReq usuario)
        {
            var usuarioResponse = usuarioRepo.VerificarUsuario(usuario);

            if (usuarioResponse.Logueado)
            {
                return RedirectToAction("Listado", "Cliente");
            }
            else
            {
                return View();
            }
        }

        public IActionResult UpdateUsuario(UsuarioReq user)
        {
            var userResponse = usuarioRepo.UpdateUsuario(user);


            return RedirectToAction("Inicio");
        }

        public IActionResult Edit(UsuarioReq user)
        {
            var userResponse = usuarioRepo.GetUsuarioUsername(user.UserName);


            return View();
        }



        public IActionResult GuardarUser(UsuarioReq user)
        {
            return RedirectToAction("Inicio");
        }


        public IActionResult VerUsuario()
        {
            return View();
        }

    }
}
