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

            ViewBag.Producto = prodRepo.GetProductos();
            return View();
        }
        public IActionResult Delete(ProductoReq prod)
        {
            prodRepo.DeleteProducto(prod);
            return RedirectToAction("Listado");
        }

        public IActionResult GuardarProd(ProductoReq prod)
        {
            var result = prodRepo.AddProducto(prod);
            return RedirectToAction("Listado");
        }

        public IActionResult AgregarProd(ProductoReq prod)
        {
            return View();
        }

        public IActionResult UpdateProducto(ProductoReq prod)
        {
            var clienteResponse = prodRepo.UpdateProducto(prod);


            return RedirectToAction("Listado");
        }

        public IActionResult Edit(ProductoReq prod)
        {
            var prodResponse = prodRepo.GetProductoCodigo(prod.Codigo);

            return View();
        }
    }
}

