namespace VentaNET.Models
{
    public class Venta : Cliente
    {
        public int Id { get; set; }

        public int IdCliente { get; set; }

        public double Total { get; set; }
    }
}
