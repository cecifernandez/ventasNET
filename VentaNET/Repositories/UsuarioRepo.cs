using VentaNET.Models;

namespace VentaNET.Repositories
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
    }
}
