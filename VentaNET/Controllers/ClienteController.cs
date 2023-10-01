using Microsoft.AspNetCore.Mvc;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.Interfaces;

namespace VentaNET.Controllers
{
    public class ClienteController : Controller
    {

        IClienteRepo clienteRepo;

        public ClienteController(IClienteRepo _clienteRepo)
        {
            clienteRepo = _clienteRepo;
        }

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

        public IActionResult AgregarCliente(ClienteReq cli)
        {
            var result = clienteRepo.AddCliente(cli);

            return View();
        }

        //[HttpPost]
        public IActionResult UpdateCliente(ClienteReq cli)
        {
            var clienteResponse = clienteRepo.UpdateCliente(cli);


            return RedirectToAction("Listado");
        }

        public IActionResult Edit(ClienteReq cli)
        {
            var clienteResponse = clienteRepo.GetClienteCuit(cli.Cuit);


            return View();
        }
        public IActionResult Delete(ClienteReq cli)
        {
            var clienteResponse = clienteRepo.DeleteCliente(cli);
            return RedirectToAction("Listado");
        }
    }
}
