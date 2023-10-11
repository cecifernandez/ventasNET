using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaNET.Models;
using VentasNET.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;

namespace VentasNet.Infra.Interfaces
{
    public interface IProductoRepo
    {

        public ProductoResponse AddProducto(ProductoReq producto);
        public Producto MapeoProducto(ProductoReq producto);
        public ProductoResponse UpdateProducto(ProductoReq producto);
        public ProductoResponse DeleteProducto(ProductoReq producto);
        public Producto GetProductoCodigo(string codigo);
        public List<ProductoReq> GetProductos();
        
    }
}
