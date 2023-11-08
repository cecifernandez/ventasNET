using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasNET.Entity.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;

namespace VentasNet.Infra.Interfaces
{
    public interface IMovCompRepo 
    {
        public MovCompResponse AddMovComp(MovimientosDeComprobanteReq pago);
        public MovimientoDeComprobantes MapeoMovComp(MovimientosDeComprobanteReq pago);
        public MovCompResponse UpdateMovComp(MovimientosDeComprobanteReq pago);
        public MovCompResponse DeleteMovComp(MovimientosDeComprobanteReq pago);
        public MovimientoDeComprobantes GetMovComp(string id);
        public List<MovimientosDeComprobanteReq> GetMovComp();
    }
}
