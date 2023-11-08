using VentasNET.Entity.Models;

namespace VentaNET.Models
{
    public class VentaReq : Cliente
    {
        public int IdVenta { get; set; }

        public int NumCbte { get; set; }

        public string NombreCli { get; set; }

        public DateTime? Fecha { get; set; }
    }
}
