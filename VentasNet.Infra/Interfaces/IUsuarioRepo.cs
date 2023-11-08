using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VentaNET.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNET.Entity.Models;

namespace VentasNet.Infra.Interfaces
{
    public interface IUsuarioRepo
    {
        public UsuarioResponse UpdateUsuario(UsuarioReq user);
        public UsuarioResponse VerificarUsuario(UsuarioReq user);
        public UsuarioResponse AddUsuario(UsuarioReq user);
        public Usuario GetUsuarioUsername(string username);
    }
}
