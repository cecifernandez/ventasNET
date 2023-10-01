using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNET.Entity.Models;

namespace VentasNet.Infra.Interfaces
{
    public interface IClienteRepo
    {
        public ClienteResponse AddCliente(ClienteReq cliente);
        public Cliente MapeoCliente(ClienteReq cliente);
        public ClienteResponse UpdateCliente(ClienteReq cliente);
        public ClienteResponse DeleteCliente(ClienteReq cliente);
        public Cliente GetClienteCuit(string cuit);
        public List<ClienteReq> GetClientes();
    }
}
