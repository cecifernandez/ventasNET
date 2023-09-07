using VentasNET.Entity.Data;
using VentaNET.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNET.Entity.Models;

namespace VentasNet.Infra.Repositories
{
    public class ClienteRepo
    {
        private readonly  VentasNetContext _context;

        public ClienteRepo() 
        { 
            _context = new VentasNetContext();
        }

        public ClienteResponse AddCliente(ClienteReq cliente)
        {
            
            ClienteResponse clienteResponse = new ClienteResponse();

            //verificar si cliente existe

            var existeCliente = GetClienteCuit(cliente.Cuit);

            if (existeCliente == null)
            {
                try
                {
                    _context.Add(cliente);
                    _context.SaveChanges();
                    clienteResponse.Guardar = true;
                    clienteResponse.RazonSocial = cliente.RazonSocial;
                }
                catch (Exception ex)
                {
                    clienteResponse.Mensaje = "Ocurrió un error al modificar cliente";
                    clienteResponse.Guardar = false;
                }

            }

            return clienteResponse;

        }

        public ClienteResponse UpdateCliente(ClienteReq cliente)
        {
            ClienteResponse clienteResponse = new ClienteResponse();

            var existeCliente = GetClienteCuit(cliente.Cuit);

            if (existeCliente != null)
            {
                try
                {
                    existeCliente.Telefeno = cliente.Telefono;
                    existeCliente.RazonSocial = cliente.RazonSocial;


                    _context.Update(existeCliente);
                    _context.SaveChanges();

                    clienteResponse.Guardar = true;
                    clienteResponse.RazonSocial = existeCliente.RazonSocial;
                }
                catch (Exception ex)
                {
                    clienteResponse.Mensaje = "Ocurrió un error al modificar cliente";
                    clienteResponse.Guardar= false;
                }

            }

            return clienteResponse;

        }
        public ClienteResponse DeleteCliente(ClienteReq cliente)
        {


            ClienteResponse clienteResponse = new ClienteResponse();

            var existeCliente = GetClienteCuit(cliente.Cuit);

            if (existeCliente != null)
            {
                try
                {
                    existeCliente.Estado = false;
                    existeCliente.FechaBaja = DateTime.Now;



                    _context.Update(existeCliente);
                    _context.SaveChanges();

                    clienteResponse.Guardar = true;
                    clienteResponse.RazonSocial = existeCliente.RazonSocial;
                }
                catch (Exception ex)
                {
                    clienteResponse.Mensaje = "Ocurrió un error al eliminar cliente";
                    clienteResponse.Guardar = false;
                }

            }

            return clienteResponse;

        }
        public Cliente GetClienteCuit(string cuit)
        {
            var cliente = _context.Cliente.Where(x => x.Cuit == cuit).FirstOrDefault();

            return cliente;  
        }

        public List<ClienteReq> GetClientes()
        {
            List<ClienteReq> listadoClientes = new List<ClienteReq>();
            var lista = _context.Cliente.Where(x => x.Estado != false).ToList();

            foreach(var item in lista)
            {
                ClienteReq clienteReq = new ClienteReq();
                clienteReq.Nombre = item.Nombre;
                clienteReq.Apellido = item.Apellido;
                clienteReq.IdCliente = item.IdCliente;
                clienteReq.Cuit = item.Cuit;
                clienteReq.RazonSocial = item.RazonSocial;
                clienteReq.Domicilio = item.Domicilio; 
                clienteReq.Localidad = item.Localidad;
                clienteReq.Telefeno = item.Telefeno;
                clienteReq.Estado = item.Estado;
                clienteReq.FechaAlta = item.FechaAlta;
                clienteReq.FechaBaja = item.FechaBaja;

                listadoClientes.Add(clienteReq);
            }
            return listadoClientes;
        }
    }
}
