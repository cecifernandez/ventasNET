using Microsoft.AspNetCore.Mvc;
using VentaNET.Models;
using VentasNet.Infra.Interfaces;
using VentasNet.Infra.Repositories;

namespace VentaNET.Controllers
{
    public class ComprobanteController : Controller
    {
        private readonly IComprobanteRepo _comprobanteRepo;

        public ComprobanteController(IComprobanteRepo comprobanteRepo)
        {
            _comprobanteRepo = comprobanteRepo;
        }
        public IActionResult ListaComprobante()
        {
            return View();
        }

        



    }
}
