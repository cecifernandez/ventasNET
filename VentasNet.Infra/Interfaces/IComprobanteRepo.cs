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
    public interface IComprobanteRepo
    {
        public ComprobanteResponse AddComprobante(ComprobanteReq comp);
        public Comprobante MapeoComp(ComprobanteReq comp);
        public ComprobanteResponse UpdateComp(ComprobanteReq comp);
        public ComprobanteResponse DeleteComp(ComprobanteReq comp);
        public Comprobante GetCompNombre(string nombre);

        public int GetSiguienteComprobante();
        public List<ComprobanteReq> GetComp();
    }
}
