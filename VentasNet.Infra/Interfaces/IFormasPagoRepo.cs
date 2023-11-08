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
    public interface IFormasPagoRepo
    {
        public FormasPagoResponse AddPago(FormasDePagoReq pago);
        public FormasDePago MapeoPago(FormasDePagoReq pago);
        public FormasPagoResponse UpdatePago(FormasDePagoReq pago);
        public FormasPagoResponse DeletePago(FormasDePagoReq pago);
        public FormasDePago GetTipoPago(string id);
        public List<FormasDePagoReq> GetPago();
    }
}
