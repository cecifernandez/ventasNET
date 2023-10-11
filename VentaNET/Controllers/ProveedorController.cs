using Microsoft.AspNetCore.Mvc;
using VentaNET.Models;
using VentasNet.Infra.Repositories;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.Interfaces;

namespace VentaNET.Controllers
{
    public class ProveedorController : Controller
    {
        IProveedorRepo proveedorRepo;

        public ProveedorController(IProveedorRepo _proveedorRepo)
        {
            proveedorRepo = _proveedorRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listado()
        {

            ViewBag.Proveedor = proveedorRepo.GetProveedores();
            return View();
        }
        public IActionResult Delete(ProveedorReq prov)
        {
            var provResponse = proveedorRepo.DeleteProveedor(prov);
            return RedirectToAction("Listado");
        }

        public IActionResult GuardarProv(ProveedorReq prov)
        {
            var result = proveedorRepo.AddProveedor(prov);
            return RedirectToAction("Listado");
        }

        public IActionResult AgregarProv(ProveedorReq prov)
        {
            
            return View();
        }

        public IActionResult Edit(ProveedorReq prov)
        {
            var provResponse = proveedorRepo.GetProveedorCuit(prov.Cuit);

            return View();
        }

        public IActionResult UpdateProveedor(ProveedorReq prov)
        {
            var provResponse = proveedorRepo.UpdateProveedor(prov);


            return RedirectToAction("Listado");
        }
    }
}
