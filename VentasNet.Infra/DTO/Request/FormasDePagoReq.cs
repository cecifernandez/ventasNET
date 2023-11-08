using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VentasNet.Infra.DTO.Request
{
    public class FormasDePagoReq
    {
        public int Id { get; set; }

        public int IdTipoPago { get; set; }

        public string Entidad { get; set; }

        public int IdFinanciacion { get; set; }

        public string Descripcion { get; set; }
    }
}
