using Microsoft.AspNetCore.Mvc;
using VentaNET.Models;
using VentaNET.Repositories;

namespace VentaNET.Controllers
{
    public class ProductoController : Controller
    {
        List<Producto> provList = new List<Producto>();
        ProductoRepo prodRepo = new ProductoRepo();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listado()
        {

            ViewBag.Producto = Listados.ListaProducto.Where(x => x.Estado == true);
            return View();
        }
        public IActionResult Delete(Producto prod)
        {
            prodRepo.DeleteProducto(prod);
            return RedirectToAction("Listado");
        }

        public IActionResult GuardarProd(Producto prod)
        {

            bool existe = false;

            Producto existeProd = new Producto();

            existe = prodRepo.VerificarProd(prod);

            if (existe)
            {
                prodRepo.ModificarProducto(prod);
            }
            else
            {
                prod.Estado = true;

                Listados.ListaProducto.Add(prod);
            }


            return RedirectToAction("Listado");
        }

        public IActionResult AgregarProd(Producto prod)
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            Producto prod = new Producto();

            prod = Listados.ListaProducto.Find(x => x.Id == id);

            return RedirectToAction("AgregarProd", prod);
        }
    }
}

