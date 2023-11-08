using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using VentaNET.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.Interfaces;
using VentasNet.Infra.Repositories;

namespace VentaNET.Controllers
{
    public class VentaController : Controller
    {
        private readonly IVenta _ventaRepo;
        private readonly IProductoRepo _productoRepo;
        private readonly IClienteRepo _clienteRepo;

        public VentaController(IVenta ventaRepo, IProductoRepo productoRepo, IClienteRepo clienteRepo)
        {
            _ventaRepo = ventaRepo;
            _productoRepo = productoRepo;
            _clienteRepo = clienteRepo;
        }
        public IActionResult Venta()
        {
            //List<ProductoReq> productList =
            ViewBag.ProductList = _productoRepo.GetProductos();


            List<ClienteReq> clientList = _clienteRepo.GetClientes();
            ViewBag.ClientList = new SelectList(clientList, "Cuit", "RazonSocial");


            ViewBag.Comprobante = _ventaRepo.GetSiguienteComprobante();
            return View();
        }

        public IActionResult GuardarVenta(VentaReq venta)
        {

            var result = _ventaRepo.AddVenta(venta);
            return View();
        }



    }
}
