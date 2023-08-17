using VentaNET.Models;

namespace VentaNET.Repositories
{
    public class ProductoRepo
    {
        public void ModificarProducto(Producto prod)
        {
            int index = Listados.ListaProducto.FindIndex(x => x.Id == x.Id);

            Listados.ListaProducto[index].IdProveedor = prod.IdProveedor;
            Listados.ListaProducto[index].NombreProducto = prod.NombreProducto;
            Listados.ListaProducto[index].Descripcion = prod.Descripcion;
            Listados.ListaProducto[index].ImporteProducto = prod.ImporteProducto;


        }

        public void DeleteProducto(Producto prod)
        {
            

            var index = Listados.ListaProducto.FindIndex(x => x.Id == prod.Id);
            Listados.ListaProducto[index].Estado = false;

        }

        public bool VerificarProd(Producto prod)
        {
            bool existe = false;

            Producto existeProd = new Producto();

            existeProd = Listados.ListaProducto.Find(x => x.Id == prod.Id);
            if (existeProd != null)
            {
                existe = true;
            }

            return existe;
        }

        public bool AgregarProd(Producto prod)
        {
            return true;

        }
    }
}
