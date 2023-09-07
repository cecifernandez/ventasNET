using VentaNET.Models;

namespace VentasNet.Infra.Repositories
{
    public class UsuarioRepo
    {
        public bool VerificarUsuario(Usuario user)
        {
            Usuario userInput = Listados.ListaUsuario.FirstOrDefault(u => u.UserName == user.UserName);

            if (userInput != null && userInput.Password == user.Password){
                return true;
            } else
            {
                return false;
            } 
        }

        public void ModificarUsuario(Usuario usuario)
        {
            Usuario user = Listados.ListaUsuario.FirstOrDefault(u => u.Password == usuario.Password);

            if (user != null)
            {
                user.Password = usuario.Password;
            }
        }

        public bool AgregarUsuario(UsuarioRepo user)
        {
            return true;

        }
    }
}
