using VentaNET.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNET.Entity.Models;

namespace VentasNet.Infra.Interfaces
{
    public interface IVenta
    {
        public int GetSiguienteComprobante();
        public VentaResponse AddVenta(VentaReq venta);

        public Venta MapeoVenta(VentaReq venta);
    }
}
