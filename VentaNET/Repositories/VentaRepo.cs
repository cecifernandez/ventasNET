using VentaNET.Models;

namespace VentaNET.Repositories
{
    public class VentaRepo
    {
        private Venta _venta = new Venta();
        public VentaRepo() { }

        public Venta VentaMostrador()
        {
            return _venta;
        }
    }
}
