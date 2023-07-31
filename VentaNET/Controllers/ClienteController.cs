using Microsoft.AspNetCore.Mvc;
using VentaNET.Models;
using VentaNET.Repositories;

namespace VentaNET.Controllers
{
    public class ClienteController : Controller
    {
        ClienteRepo cliente = new ClienteRepo();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listado()
        {

            ViewBag.Cliente = cliente.ListaDeClientes();
            return View();
        }
    }
}
