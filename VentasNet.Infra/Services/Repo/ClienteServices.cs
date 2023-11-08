
using VentasNet.Infra.Services.Interfaces;
using VentasNET.Entity.Data;
using VentasNET.Entity.Models;

namespace VentasNet.Infra.Services.Repo
{
    public class ClienteServices : IClienteService
    {
        private readonly VentasNetContext _context;


        public ClienteServices(VentasNetContext context)
        {
            _context = context;
        }

        public void CrearNuevoCliente(Cliente cliente)
        {
                _context.Add(cliente);
                _context.SaveChanges();
        }

        public void EliminarCliente(int id)
        {
            var cliente = _context.Cliente.Where(x => x.IdCliente == id && x.Estado == true).FirstOrDefault();

            if (cliente != null) 
            {
                cliente.Estado = false;
                cliente.FechaBaja = DateTime.Now;
                _context.Update(cliente);
                _context.SaveChanges();
            }

            
        }

        public void ModificarCliente(Cliente cliente)
        {
            var cli = _context.Cliente.Where(x => x.IdCliente == cliente.IdCliente).FirstOrDefault();

            if (cliente != null)
            {
                cliente.Estado = false;
                cliente.FechaBaja = DateTime.Now;
                _context.Update(cliente);
                _context.SaveChanges();
            }
        }
    }
}
