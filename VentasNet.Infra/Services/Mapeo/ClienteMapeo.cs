using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentasNet.Infra.DTO.Request;
using VentasNET.Entity.Models;

namespace VentasNet.Infra.Services.Mapeo
{
    public static class ClienteMapeo
    {
        public static Cliente ReqAModelo(ClienteReq objCli)
        {
            var cli = objCli.ToModel();
            var req = cli.ToReq();


            Cliente cliente = new Cliente()
            {
                Apellido = objCli.Apellido,
                Nombre = objCli.Nombre,
                Cuit = objCli.Cuit,
                Domicilio = objCli.Domicilio,
                Telefeno = objCli.Telefeno,
                IdCliente = objCli.IdCliente,
                RazonSocial = objCli.RazonSocial,
                Localidad = objCli.Localidad,
                Provincia = objCli.Provincia,
                Estado = objCli.Estado,
                FechaAlta = objCli.FechaAlta,
                FechaBaja = objCli.FechaBaja,
                IdUsuario = objCli.IdUsuario,
            };

            return cliente;
        }
    }
}
