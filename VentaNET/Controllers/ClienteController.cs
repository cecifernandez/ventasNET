using Microsoft.AspNetCore.Mvc;
using VentaNET.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.Repositories;

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

            ViewBag.Cliente = clienteRepo.GetClientes();
            return View();
        }
       

        public IActionResult GuardarCliente(ClienteReq cliente)
        {  
            return RedirectToAction("Listado");
        }

        public IActionResult AddCliente(ClienteReq cli)
        {
            var result = clienteRepo.AddCliente(cli);

            return View();
        }

        public IActionResult Edit(ClienteReq cli)
        {
            var clienteResponse = clienteRepo.UpdateCliente(cli);


            return RedirectToAction("AgregarCliente", cli);
        }
        public IActionResult Delete(ClienteReq cli)
        {
            var clienteResponse = clienteRepo.DeleteCliente(cli);
            return RedirectToAction("Listado");
        }
    }
}
