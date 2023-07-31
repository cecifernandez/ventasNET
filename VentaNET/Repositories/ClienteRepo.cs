using VentaNET.Models;

namespace VentaNET.Repositories
{
    public class ClienteRepo
    {
        public ClienteRepo() { }

        public bool AgregarCliente()
        {
            return false;
        }

        public List<Cliente> ListaDeClientes()
        {
            List<Cliente> listadoCliente = new List<Cliente>();
            listadoCliente.Add(new Cliente() { Id = 1, RazonSocial = "Ceci.Com", Cuit = "2321312", Domicilio = "Lanus", Provincia = "Buenos Aires" });

            Cliente cli = new Cliente() { Id = 2, RazonSocial = "Yo.Com", Cuit = "233221312", Domicilio = "Lanus", Provincia = "Buenos Aires" };
            listadoCliente.Add(cli);

            return listadoCliente;
        }
  

    }
}
