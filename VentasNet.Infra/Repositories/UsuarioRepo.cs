using VentasNET.Entity.Data;
using VentaNET.Models;
using VentasNet.Infra.DTO.Request;
using VentasNet.Infra.DTO.Response;
using VentasNET.Entity.Models;
using VentasNet.Infra.Interfaces;

namespace VentasNet.Infra.Repositories
{
    public class UsuarioRepo : IUsuarioRepo
    {
        private readonly VentasNetContext _context;

        //Inyectar dependencia
        public UsuarioRepo(VentasNetContext context)
        {
            _context = context;
        }
        public UsuarioResponse UpdateUsuario(UsuarioReq usuario)
        {
            UsuarioResponse usuarioResponse = new UsuarioResponse();

            var existeUser = _context.Usuario.Where(x => x.Password == usuario.Password).FirstOrDefault();

            if (existeUser != null)
            {
                try
                {
                    existeUser.Password = usuario.Password != null ? usuario.Password : existeUser.Password;
                    existeUser.UserName = usuario.UserName != null ? usuario.UserName : existeUser.UserName;
                    existeUser.Email = usuario.Email != null ? usuario.Email : existeUser.Email;
                    existeUser.IdTipoUsuario = usuario.IdTipoUsuario;   

                    _context.Update(existeUser);
                    _context.SaveChanges();

                    usuarioResponse.Guardar = true;
                    
                }
                catch (Exception ex)
                {
                    usuarioResponse.Mensaje = "Ocurrió un error al modificar cliente";
                    usuarioResponse.Guardar = false;
                }
            }

            return usuarioResponse;
        }

        public UsuarioResponse VerificarUsuario(UsuarioReq usuario)
        {
            UsuarioResponse usuarioResponse = new UsuarioResponse();

            var user = _context.Usuario.Where(x => x.UserName == usuario.UserName).FirstOrDefault();

            if (user != null && user.Password == usuario.Password) 
            {
                try 
                {
                    usuarioResponse.Logueado = true;
                    usuarioResponse.Mensaje = "Bienvenido";

                }
                catch (Exception ex) 
                {
                    usuarioResponse.Logueado = false;
                    usuarioResponse.Mensaje = "Usuario o contraseña incorrectos";
                }
            }

            return usuarioResponse;
        }


        public Usuario GetUsuarioUsername(string username) 
        {
            var user = _context.Usuario.Where(x => x.UserName == username).FirstOrDefault();

            return user;
        }

      

        //public bool AgregarUsuario(UsuarioRepo user)
        //{
        //    return true;

        //}
    }
}
