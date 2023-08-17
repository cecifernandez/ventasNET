using VentaNET.Models;

namespace VentaNET.Repositories
{
    public class ProveedorRepo
    {
        public void ModificarProveedor(Proveedor proveedor)
        {
            int index = Listados.ListaProveedor.FindIndex(x => x.Id == x.Id);

            Listados.ListaProveedor[index].RazonSocial = proveedor.RazonSocial;
            Listados.ListaProveedor[index].Cuit = proveedor.Cuit;
            Listados.ListaProveedor[index].Provincia = proveedor.Provincia;
            Listados.ListaProveedor[index].Domicilio = proveedor.Domicilio;


        }

        public void DeleteProveedor(Proveedor proveedor)
        {
            

            var index = Listados.ListaProveedor.FindIndex(x => x.Id == proveedor.Id);
            Listados.ListaProveedor[index].Estado = false;

        }

        public bool VerificarProv(Proveedor proveedor)
        {
            bool existe = false;

            Proveedor existeProv = new Proveedor();

            existeProv = Listados.ListaProveedor.Find(x => x.Id == proveedor.Id);
            if (existeProv != null)
            {
                existe = true;
            }

            return existe;
        }

        public bool AgregarProv(Proveedor proveedor)
        {
            return true;

        }
    }
}
