
using VentasNet.Infra.DTO.Request;
using VentasNET.Entity.Models;

namespace VentasNet.Infra.Services.Mapeo
{
    public static class ProductoMapeo
    {
        public static Producto ReqAModelo(ProductoReq objProd)
        {
            var prod = objProd.ToModel();
            var req = prod.ToReq();


            Producto producto = new Producto()
            {
                IdProveedor = objProd.IdProveedor,
                NombreProducto = objProd.NombreProducto,
                Descripcion = objProd.Descripcion,
                ImporteProducto = objProd.ImporteProducto,
                Codigo = objProd.Codigo,
                IdProducto = objProd.Id,
                Estado = objProd.Estado,
            };

            return producto;
        }
    }
}
