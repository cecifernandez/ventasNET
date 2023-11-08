using VentasNET.Entity.Data;
using VentaNET.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNET.Entity.Models;
using VentasNet.Infra.Interfaces;

namespace VentasNet.Infra.Repositories
{
    public class VentaRepo : IVenta
    {
        private readonly VentasNetContext _context;


        public VentaRepo(VentasNetContext context) 
        {
            _context = context;
        }


        public int GetSiguienteComprobante()
        {
            var numCbte = _context.Venta.Where(x => x.NumCbte != null).FirstOrDefault();
            if(numCbte != null)
            {
                return numCbte.NumCbte;
            } else
            {
                return 1;
            }
        }

        public VentaResponse AddVenta(VentaReq venta)
        {
            VentaResponse ventaResponse = new VentaResponse();

            
            if (venta.IdVenta != null)
            {
                var existeVenta = GetVenta(venta.NumCbte);

                if (existeVenta == null)
                {                   
                        var vtaNew = MapeoVenta(venta);

                        vtaNew.Estado = true;
                        


                        _context.Add(vtaNew);
                        _context.SaveChanges();
                        ventaResponse.Guardar = true;
                        
                   
                }
            }

            return ventaResponse;
        }

        public Venta GetVenta(int num)
        {
            var venta = _context.Venta.Where(x => x.NumCbte == num).FirstOrDefault();

            return venta;
        }

        public Venta MapeoVenta(VentaReq venta)
        {
            Venta vta = new Venta()
            {
                NumCbte = GetSiguienteComprobante(),
                NombreCli = venta.NombreCli != null ? venta.NombreCli : string.Empty,
                Fecha = venta.Fecha != null ? venta.Fecha : DateTime.Now,
            };

            return vta;
        }

    }


}
