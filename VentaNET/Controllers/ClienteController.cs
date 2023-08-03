using Microsoft.AspNetCore.Mvc;
using VentaNET.Models;
using VentaNET.Repositories;

namespace VentaNET.Controllers
{
    public class ClienteController : Controller
    {
        ClienteRepo clienteRepo = new ClienteRepo();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listado()
        {

            ViewBag.Cliente = clienteRepo.ListaDeClientes();
            return View();
        }

        
        public IActionResult GuardarCliente(Cliente cliente)
        {
            //instanciar obj cliente 
            //pasar ese objeto al listado ListaDeClientes()
            //llenar el objeto Cliente
            
            return View();
        }

        public IActionResult AgregarCliente()
        {

            return View();
        }
    }
}
