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
    public interface IMovProvRepo
    {
        public MovProvResponse AddMovProv(MovimientosDeProveedoresReq prov);
        public MovimientoDeProveedores MapeoMovProv(MovimientosDeProveedoresReq prov);
        public MovProvResponse UpdateMovProv(MovimientosDeProveedoresReq prov);
        public MovProvResponse DeleteMovProv(MovimientosDeProveedoresReq prov);
        public MovimientoDeProveedores GetMovProv(string id);
        public List<MovimientosDeProveedoresReq> GetMovProv();
    }
}
