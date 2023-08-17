using Microsoft.AspNetCore.Mvc;
using VentaNET.Models;
using VentaNET.Repositories;

namespace VentaNET.Controllers
{
    public class ProveedorController : Controller
    {
        List<Proveedor> provList = new List<Proveedor>();
        ProveedorRepo provRepo = new ProveedorRepo();

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
        public IActionResult Delete(Proveedor prov)
        {
            provRepo.DeleteProveedor(prov);
            return RedirectToAction("Listado");
        }

        public IActionResult GuardarProv(Proveedor prov)
        {

            bool existe = false;

            Proveedor existeProv = new Proveedor();

            existe = provRepo.VerificarProv(prov);

            if (existe)
            {
                provRepo.ModificarProveedor(prov);
            }
            else
            {
                prov.Estado = true;

                Listados.ListaProveedor.Add(prov);
            }


            return RedirectToAction("Listado");
        }

        public IActionResult AgregarProv(Proveedor prov)
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            Proveedor prov = new Proveedor();

            prov = Listados.ListaProveedor.Find(x => x.Id == id);

            return RedirectToAction("AgregarProv", prov);
        }
    }
}
