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

        public static List<Venta> ListaVentas { get; set; } = new List<Venta>();
        public static List<Usuario> ListaUsuario { get; set; } = new List<Usuario>() { new Usuario { IdUsuario = 1, UserName = "admin", Password = "admin" } };
    }
}
