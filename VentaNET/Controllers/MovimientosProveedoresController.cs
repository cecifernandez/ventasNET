using Microsoft.AspNetCore.Mvc;

namespace VentaNET.Controllers
{
    public class MovimientosProveedoresController : Controller
    {
        public IActionResult ListaMovProv()
        {
            return View();
        }
    }
}
