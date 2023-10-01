using VentaNET.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNET.Entity.Models;

namespace VentasNet.Infra.Interfaces
{
    public interface IProveedorRepo
    {
        public ProveedorResponse AddProveedor(ProveedorReq proveedor);
        public Proveedor MapeoProveedor(ProveedorReq proveedor);
        public ProveedorResponse UpdateProveedor(ProveedorReq proveedor);
        public ProveedorResponse DeleteProveedor(ProveedorReq proveedor);
        public Proveedor GetProveedorCuit(string cuit);
        public List<ProveedorReq> GetProveedores();
    }
}
