using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasNET.Entity.Models;

namespace VentasNet.Infra.DTO.Request
{
    public class MovimientosDeComprobanteReq
    {
        public int Id { get; set; }

        public int IdComprobante { get; set; }

        public int? IdMovimientoProveedor { get; set; }

        public decimal Importe { get; set; }

        public decimal? Descuento { get; set; }

        public decimal Total { get; set; }

        public virtual Comprobante IdComprobanteNavigation { get; set; }
    }
}
