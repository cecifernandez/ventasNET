using Microsoft.AspNetCore.Mvc;

namespace VentaNET.Controllers
{
    public class StockController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListadoProductos() 
        {
            return View();
        }
    }
}
