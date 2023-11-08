using Microsoft.AspNetCore.Mvc;

namespace VentaNET.Controllers
{
    public class StockController : Controller
    {
        public IActionResult ListaStock()
        {
            return View();
        }
    }
}
