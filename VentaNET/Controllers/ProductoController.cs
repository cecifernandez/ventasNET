using Microsoft.AspNetCore.Mvc;
using VentaNET.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.Interfaces;
using VentasNet.Infra.Repositories;

namespace VentaNET.Controllers
{
    public class ProductoController : Controller
    {
        IProductoRepo prodRepo;

        public ProductoController(IProductoRepo _prodRepo)
        {
            prodRepo = _prodRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listado()
        {

            ViewBag.Producto = Listados.ListaProducto.Where(x => x.Estado == true);
            return View();
        }
        public IActionResult Delete(ProductoReq prod)
        {
            prodRepo.DeleteProducto(prod);
            return RedirectToAction("Listado");
        }

        public IActionResult GuardarProd(ProductoReq prod)
        {

            return RedirectToAction("Listado");
        }

        public IActionResult AgregarProd(ProductoReq prod)
        {
            return View();
        }

        public IActionResult Edit(ProductoReq prod)
        {
            var prodResponse = prodRepo.UpdateProducto(prod);

            return RedirectToAction("AgregarProd", prod);
        }
    }
}

