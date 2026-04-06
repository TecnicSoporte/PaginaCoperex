using PaginaWebCoperex.Models;

namespace PaginaWebCoperex.Services.LoginServices
{
    public interface ILoginService
    {
        Task<RespuestaAutenticacion> Login(CredencialesUsuario credencialesUsuario);
        Task<RespuestaAutenticacion> RenovarToken(string email);
    }
}
