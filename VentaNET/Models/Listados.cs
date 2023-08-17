namespace VentaNET.Models
{
    public static class Listados
    {
        public static List<Cliente> ListaCliente { get; set; } = new List<Cliente>();
        public static List<Proveedor> ListaProveedor { get; set; } = new List<Proveedor>();
        public static List<Producto> ListaProducto { get; set; } = new List<Producto>();

        public static List<ProductoVendido> ListaProductoVendido { get; set; } = new List<ProductoVendido>();

        public static List<Venta> ListaVentas { get; set; } = new List<Venta>();
        public static List<Usuario> ListaUsuario { get; set; } = new List<Usuario>() { new Usuario { Id = 1, UserName = "admin", Password = "admin" } };
    }
}
