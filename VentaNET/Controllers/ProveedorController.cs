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
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Listado()
        {

            ViewBag.Proveedor = Listados.ListaProveedor.Where(x => x.Estado == true);
            return View();
        }
        public IActionResult Delete(ProveedorReq prov)
        {
            proveedorRepo.DeleteProveedor(prov);
            return RedirectToAction("Listado");
        }

        public IActionResult GuardarProv(ProveedorReq prov)
        { 
            return RedirectToAction("Listado");
        }

        public IActionResult AgregarProv(ProveedorReq prov)
        {
            return View();
        }

        public IActionResult Edit(ProveedorReq prov)
        {
            var provResponse = proveedorRepo.UpdateProveedor(prov);

            return RedirectToAction("AgregarProv", prov);
        }
    }
}
