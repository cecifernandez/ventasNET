using Microsoft.AspNetCore.Mvc;
using VentaNET.Models;
using VentaNET.Repositories;

namespace VentaNET.Controllers
{
    public class ClienteController : Controller
    {
        
        List<Cliente> clienteList = new List<Cliente>();
        ClienteRepo clienteRepo = new ClienteRepo();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listado()
        {

            ViewBag.Cliente = Listados.ListaCliente.Where(x => x.Estado == true);
            return View();
        }
        public IActionResult Delete(Cliente cli)
        {
            clienteRepo.DeleteCliente(cli);
            return RedirectToAction("Listado"); 
        }

        public IActionResult GuardarCliente(Cliente cliente)
        {

            bool existe = false;

            Cliente existeCliente = new Cliente();

            existe = clienteRepo.VerificarCliente(cliente);

            if(existe)
            {
                clienteRepo.ModificarCliente(cliente);
            }
            else
            {
                cliente.Estado = true;

                Listados.ListaCliente.Add(cliente);
            }
            
            
            return RedirectToAction("Listado");
        }

        public IActionResult AgregarCliente(Cliente cli)
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            Cliente cli = new Cliente();

            cli = Listados.ListaCliente.Find(x => x.Id == id);

            return RedirectToAction("AgregarCliente", cli);
        }
    }
}
