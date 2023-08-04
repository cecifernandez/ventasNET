using Microsoft.AspNetCore.Mvc;

namespace VentaNET.Controllers
{
    public class ProveedoresController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListadoProveedores()
        {
            return View();
        }
    }
}
