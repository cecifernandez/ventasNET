using VentaNET.Models;

namespace VentaNET.Repositories
{
    public class ClienteRepo
    {

        public void ModificarCliente(Cliente cliente)
        {
            int index = Listados.ListaCliente.FindIndex(x=> x.Id == x.Id);
           
                Listados.ListaCliente[index].RazonSocial = cliente.RazonSocial;
                Listados.ListaCliente[index].Cuit = cliente.Cuit;
                Listados.ListaCliente[index].Provincia = cliente.Provincia;
                Listados.ListaCliente[index].Domicilio = cliente.Domicilio;
            
             
        }

        public void DeleteCliente(Cliente cliente)
        {
             //Cliente cli = new Cliente();

            var index = Listados.ListaCliente.FindIndex(x => x.Id == cliente.Id);
            Listados.ListaCliente[index].Estado = false;
            
        }

        public  bool VerificarCliente(Cliente cliente)
        {
            bool existe = false;

            Cliente existeCliente = new Cliente();

            existeCliente = Listados.ListaCliente.Find(x => x.Id == cliente.Id);
            if(existeCliente != null)
            {
                existe = true;  
            }

            return existe;
        }

        public bool AgregarCliente(Cliente cliente)
        {
            return true;
            
        }
       

    }
}
