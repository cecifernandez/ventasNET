using VentasNET.Entity.Data;
using VentaNET.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNET.Entity.Models;
using VentasNet.Infra.Interfaces;

namespace VentasNet.Infra.Repositories
{
    public class ClienteRepo : IClienteRepo
    {
        private readonly VentasNetContext _context;

        //Inyectar dependencia
        public ClienteRepo(VentasNetContext context)
        {
            _context = context;
        }

        public ClienteResponse AddCliente(ClienteReq cliente)
        {

            ClienteResponse clienteResponse = new ClienteResponse();

            //verificar si cliente existe
            if (cliente.Cuit != null)
            {
                var existeCliente = GetClienteCuit(cliente.Cuit);

                if (existeCliente == null)
                {
                    try
                    {
                        var clienteNew = MapeoCliente(cliente);

                        clienteNew.Estado = true;
                        clienteNew.FechaAlta = DateTime.Now;



                        _context.Add(clienteNew);
                        _context.SaveChanges();
                        clienteResponse.Guardar = true;
                        clienteResponse.RazonSocial = clienteNew.RazonSocial;
                    }
                    catch (Exception ex)
                    {
                        clienteResponse.Mensaje = "Ocurrió un error al modificar cliente";
                        clienteResponse.Guardar = false;
                    }

                }
            }

            return clienteResponse;

        }

        public Cliente MapeoCliente(ClienteReq cliente)
        {
            Cliente cliente1 = new Cliente()
            {
                Apellido = cliente.Apellido != null ? cliente.Apellido : string.Empty,
                Nombre = cliente.Nombre != null ? cliente.Nombre : string.Empty,
                Cuit = cliente.Cuit != null ? cliente.Cuit : string.Empty,
                Domicilio = cliente.Domicilio != null ? cliente.Domicilio : string.Empty,
                Telefeno = cliente.Telefeno != null ? cliente.Telefeno : string.Empty,
                RazonSocial = cliente.RazonSocial != null ? cliente.RazonSocial : string.Empty,
                Localidad = cliente.Localidad != null ? cliente.Localidad : string.Empty,
                Provincia = cliente.Provincia != null ? cliente.Provincia : string.Empty,
                Estado = cliente.Estado != null ? cliente.Estado : true,
                FechaAlta = cliente.FechaAlta != null ? cliente.FechaAlta : DateTime.Now,
                FechaBaja = cliente.FechaBaja != null ? cliente.FechaBaja : DateTime.Now,
                IdUsuario = cliente.IdUsuario,
            };

            return cliente1;
        }

        public ClienteResponse UpdateCliente(ClienteReq cliente)
        {
            ClienteResponse clienteResponse = new ClienteResponse();

            var existeCliente = GetClienteCuit(cliente.Cuit);

            if (existeCliente != null)
            {
                try
                {
                    existeCliente.Apellido = cliente.Apellido != null ? cliente.Apellido : existeCliente.Apellido;
                    existeCliente.Nombre = cliente.Nombre != null ? cliente.Nombre : existeCliente.Nombre;
                    existeCliente.Cuit = cliente.Cuit != null ? cliente.Cuit : existeCliente.Cuit;
                    existeCliente.Domicilio = cliente.Domicilio != null ? cliente.Domicilio : existeCliente.Domicilio;
                    existeCliente.Telefeno = cliente.Telefeno != null ? cliente.Telefeno : existeCliente.Telefeno;
                    //existeCliente.IdCliente = cliente.IdCliente != null ? cliente.IdCliente : existeCliente.IdCliente;
                    existeCliente.RazonSocial = cliente.RazonSocial != null ? cliente.RazonSocial : existeCliente.RazonSocial;
                    existeCliente.Localidad = cliente.Localidad != null ? cliente.Localidad : existeCliente.Localidad;
                    existeCliente.Provincia = cliente.Provincia != null ? cliente.Provincia : existeCliente.Provincia;
                    existeCliente.Estado = /*cliente.Estado != null ? cliente.Estado : */true;
                    //existeCliente.FechaAlta = cliente.FechaAlta != null ? cliente.FechaAlta : existeCliente.FechaAlta;
                    //existeCliente.FechaBaja = cliente.FechaBaja;
                    //existeCliente.IdUsuario = cliente.IdUsuario != null ? cliente.IdUsuario : existeCliente.IdUsuario;


                    _context.Update(existeCliente);
                    _context.SaveChanges();

                    clienteResponse.Guardar = true;
                    clienteResponse.RazonSocial = existeCliente.RazonSocial;
                }
                catch (Exception ex)
                {
                    clienteResponse.Mensaje = "Ocurrió un error al modificar cliente";
                    clienteResponse.Guardar = false;
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

            foreach (var item in lista)
            {
                ClienteReq clienteReq = new ClienteReq();
                clienteReq.Nombre = item.Nombre;
                clienteReq.Apellido = item.Apellido;
                clienteReq.IdCliente = item.IdCliente;
                clienteReq.Cuit = item.Cuit;
                clienteReq.RazonSocial = item.RazonSocial;
                clienteReq.Provincia = item.Provincia;
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

        public Cliente ValidarCliente(ClienteReq cliente)
        {
            Cliente cliente1 = new Cliente()
            {
                Apellido = cliente.Apellido != null ? string.Empty : cliente.Apellido,
                Nombre = cliente.Nombre != null ? string.Empty : cliente.Nombre,
                Cuit = cliente.Cuit != null ? string.Empty : cliente.Cuit,
                Domicilio = cliente.Domicilio != null ? string.Empty : cliente.Domicilio,
                Telefeno = cliente.Telefeno != null ? string.Empty : cliente.Telefeno,
                IdCliente = cliente.IdCliente,
                RazonSocial = cliente.RazonSocial != null ? string.Empty : cliente.RazonSocial,
                Localidad = cliente.Localidad != null ? string.Empty : cliente.Localidad,
                Provincia = cliente.Provincia != null ? string.Empty : cliente.Provincia,
                Estado = cliente.Estado != null ? cliente.Estado : true,
                FechaAlta = cliente.FechaAlta != null ? cliente.FechaAlta : DateTime.Now,
                FechaBaja = cliente.FechaBaja != null ? cliente.FechaBaja : DateTime.Now,
                IdUsuario = cliente.IdUsuario,
            };

            return cliente1;
        }
    }


}