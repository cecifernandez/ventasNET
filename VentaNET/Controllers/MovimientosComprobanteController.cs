using Microsoft.AspNetCore.Mvc;

namespace VentaNET.Controllers
{
    public class MovimientosComprobanteController : Controller
    {
        public IActionResult ListaMov()
        {
            return View();
        }
    }
}
