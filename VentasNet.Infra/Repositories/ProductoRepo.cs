using VentasNET.Entity.Data;
using VentaNET.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNET.Entity.Models;
using VentasNet.Infra.Interfaces;


namespace VentasNet.Infra.Repositories
{
    public class ProductoRepo : IProductoRepo
    {
        private readonly VentasNetContext _context;

        //Inyectar dependencia
        public ProductoRepo(VentasNetContext context)
        {
            _context = context;
        }

        public Producto GetProductoId(int id)
        {
            var prod = _context.Producto.Where(x => x.Id == id).FirstOrDefault();

            return prod;
        }

        public List<ProductoReq> GetProductos()
        {
            List<ProductoReq> listadoProd = new List<ProductoReq>();
            var lista = _context.Producto.Where(x => x.Estado != false).ToList();

            foreach (var item in lista)
            {
                ProductoReq prodReq = new ProductoReq();
                prodReq.IdProveedor = item.IdProveedor;
                prodReq.NombreProducto = item.NombreProducto;
                prodReq.Descripcion = item.Descripcion;
                prodReq.ImporteProducto = item.ImporteProducto;
                prodReq.Id = item.Id;
                prodReq.Estado = item.Estado;
            

                listadoProd.Add(prodReq);
            }
            return listadoProd;
        }

        public Producto MapeoProducto(ProductoReq producto)
        {
            Producto prod = new Producto()
            {
                IdProveedor = producto.IdProveedor,
                NombreProducto = producto.NombreProducto,
                Descripcion = producto.Descripcion,
                ImporteProducto = (int)producto.ImporteProducto,
                Id = producto.Id,
                Estado = producto.Estado

            };

            return prod;
        }

        public ProductoResponse AddProducto(ProductoReq producto)
        {
            ProductoResponse prodResponse = new ProductoResponse();

            //verificar si prod existe
            if (producto.Id != null)
            {
                var existeProd = GetProductoId(producto.Id);

                if (existeProd == null)
                {
                    try
                    {
                        var prodNew = MapeoProducto(producto);

                        prodNew.Estado = true;
                        //prodNew.FechaAlta = DateTime.Now;
                        //prodNew.FechaBaja = DateTime.MinValue;


                        _context.Add(prodNew);
                        _context.SaveChanges();
                        prodResponse.Guardar = true;
                        prodResponse.NombreProducto = prodResponse.NombreProducto;
                    }
                    catch (Exception ex)
                    {
                        prodResponse.Mensaje = "Ocurrió un error al modificar producto";
                        prodResponse.Guardar = false;
                    }

                }
            }

            return prodResponse;
        }

        public ProductoResponse DeleteProducto(ProductoReq producto)
        {
            ProductoResponse prodResponse = new ProductoResponse();

            var existeProd = GetProductoId(producto.Id);

            if (existeProd != null)
            {
                try
                {
                    existeProd.Estado = false;
                    



                    _context.Update(existeProd);
                    _context.SaveChanges();

                    prodResponse.Guardar = true;
                    prodResponse.NombreProducto = prodResponse.NombreProducto;
                }
                catch (Exception ex)
                {
                    prodResponse.Mensaje = "Ocurrió un error al eliminar producto";
                    prodResponse.Guardar = false;
                }

            }

            return prodResponse;
        }

        public ProductoResponse UpdateProducto(ProductoReq producto)
        {
            ProductoResponse prodResponse = new ProductoResponse();

            var existeProd = GetProductoId(producto.Id);

            if (existeProd != null)
            {
                try
                {
                    existeProd.NombreProducto = producto.NombreProducto;
                    existeProd.Descripcion = producto.Descripcion;
                    

                    _context.Update(existeProd);
                    _context.SaveChanges();

                    prodResponse.Guardar = true;
                    prodResponse.NombreProducto = prodResponse.NombreProducto;
                }
                catch (Exception ex)
                {
                    prodResponse.Mensaje = "Ocurrió un error al eliminar producto";
                    prodResponse.Guardar = false;
                }

            }

            return prodResponse;
        }
    }
}
