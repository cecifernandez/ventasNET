using Microsoft.AspNetCore.Mvc;

namespace VentaNET.Controllers
{
    public class PagoController : Controller
    {
        public IActionResult ListaPago()
        {
            return View();
        }
    }
}
