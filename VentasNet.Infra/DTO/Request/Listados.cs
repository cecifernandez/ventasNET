using VentasNet.Infra.DTO.Request;
using VentasNET.Entity.Models;

namespace VentaNET.Models
{
    public static class Listados
    {
        public static List<ClienteReq> ListaCliente { get; set; } = new List<ClienteReq>();
        public static List<Proveedor> ListaProveedor { get; set; } = new List<Proveedor>();
        public static List<Producto> ListaProducto { get; set; } = new List<Producto>();

        public static List<ProductoVendido> ListaProductoVendido { get; set; } = new List<ProductoVendido>();

        public static List<VentaReq> ListaVentas { get; set; } = new List<VentaReq>();
        public static List<Stock> ListaStock { get; set; } = new List<Stock>();
        public static List<Comprobante> ListaComprobante { get; set; } = new List<Comprobante>();
        public static List<MovimientoDeProveedores> ListaMovProv { get; set; } = new List<MovimientoDeProveedores>();
        public static List<MovimientoDeComprobantes> ListaMovComp { get; set; } = new List<MovimientoDeComprobantes>();
        public static List<FormasDePago> ListaFormasPago { get; set; } = new List<FormasDePago>();
        public static List<Usuario> ListaUsuario { get; set; } = new List<Usuario>() { new Usuario { IdUsuario = 1, UserName = "admin", Password = "admin" } };
    }
}
