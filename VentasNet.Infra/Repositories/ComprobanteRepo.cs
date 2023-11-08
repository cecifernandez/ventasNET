using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNet.Infra.Interfaces;
using VentasNET.Entity.Data;
using VentasNET.Entity.Models;

namespace VentasNet.Infra.Repositories
{
    public class ComprobanteRepo : IComprobanteRepo
    {
        private readonly VentasNetContext _context;

        public ComprobanteRepo(VentasNetContext context)
        {
            _context = context;
        }

        

        public ComprobanteResponse AddComprobante(ComprobanteReq comp)
        {
            throw new NotImplementedException();
        }

        public ComprobanteResponse DeleteComp(ComprobanteReq comp)
        {
            throw new NotImplementedException();
        }

        public List<ComprobanteReq> GetComp()
        {
            throw new NotImplementedException();
        }

        public Comprobante GetCompNombre(string nombre)
        {
            throw new NotImplementedException();
        }

        public int GetSiguienteComprobante()
        {
            throw new NotImplementedException();
        }

        public Comprobante MapeoComp(ComprobanteReq comp)
        {
            throw new NotImplementedException();
        }

        public ComprobanteResponse UpdateComp(ComprobanteReq comp)
        {
            throw new NotImplementedException();
        }
    }
}
