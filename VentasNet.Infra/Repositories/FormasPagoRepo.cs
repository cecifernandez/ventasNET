using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNet.Infra.Interfaces;
using VentasNET.Entity.Models;

namespace VentasNet.Infra.Repositories
{
    public class FormasPagoRepo : IFormasPagoRepo
    {
        public FormasPagoResponse AddPago(FormasDePagoReq pago)
        {
            throw new NotImplementedException();
        }

        public FormasPagoResponse DeletePago(FormasDePagoReq pago)
        {
            throw new NotImplementedException();
        }

        public List<FormasDePagoReq> GetPago()
        {
            throw new NotImplementedException();
        }

        public FormasDePago GetTipoPago(string id)
        {
            throw new NotImplementedException();
        }

        public FormasDePago MapeoPago(FormasDePagoReq pago)
        {
            throw new NotImplementedException();
        }

        public FormasPagoResponse UpdatePago(FormasDePagoReq pago)
        {
            throw new NotImplementedException();
        }
    }
}
