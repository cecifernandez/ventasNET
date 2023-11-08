using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasNet.Infra.DTO.Request
{
    public class MovimientosDeProveedoresReq
    {
        public int Id { get; set; }

        public string Comprobante { get; set; }

        public DateTime FechaComprobante { get; set; }

        public decimal ImporteTotal { get; set; }

        public decimal? Descuentos { get; set; }

        public byte[] FechaMovimiento { get; set; }

        public int IdUsuario { get; set; }
    }
}
