using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasNET.Entity.Models;

namespace VentasNet.Infra.DTO.Request
{
    public class ComprobanteReq
    {
        public int IdComprobante { get; set; }

        public string Nombre { get; set; }

        public string NombreCorto { get; set; }

        public string Descripcion { get; set; }

        public int NroCbte { get; set; }

        public int? NroSucursal { get; set; }


        public byte[] FechaMovimiento { get; set; }

        public virtual ICollection<MovimientoDeComprobantes> MovimientoDeComprobantes { get; set; } = new List<MovimientoDeComprobantes>();

        public virtual ICollection<Stock> Stock { get; set; } = new List<Stock>();
    }
}
