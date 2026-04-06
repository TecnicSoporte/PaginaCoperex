using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PaginaWebCoperex.Models;

namespace PaginaWebCoperex.Services.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly string llavejwt;
        private readonly IDbContextFactory<PaginaWebContext> _dbContextFactory;

        public LoginService(IConfiguration iConfiguration, IDbContextFactory<PaginaWebContext> dbContextFactory)
        {
            llavejwt = iConfiguration["llavejwt"];
            _dbContextFactory = dbContextFactory;
        }

        // DTO actualizado para el modelo Usuario
        private class UsuarioLoginDto
        {
            public int IdUsuario { get; set; }
            public string PrimerNombre { get; set; } = "";
            public string SegundoNombre { get; set; } = "";
            public string PrimerApellido { get; set; } = "";
            public string SegundoApellido { get; set; } = "";
            public string Correo { get; set; } = "";
            public string Password { get; set; } = "";
            public int? Rol { get; set; }
            public string? RolTipo { get; set; }
        }

        #region Métodos de Hash

        private string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                return string.Empty;

            try
            {
                using (var sha256 = SHA256.Create())
                {
                    var bytes = Encoding.UTF8.GetBytes(password);
                    var hash = sha256.ComputeHash(bytes);
                    return Convert.ToBase64String(hash);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al hashear contraseña: {ex.Message}");
                return string.Empty;
            }
        }

        private bool VerifyPassword(string plainTextPassword, string hashedPassword)
        {
            if (string.IsNullOrEmpty(plainTextPassword) || string.IsNullOrEmpty(hashedPassword))
                return false;

            try
            {
                var hashOfInput = HashPassword(plainTextPassword);
                return string.Equals(hashOfInput, hashedPassword, StringComparison.Ordinal);
            }
            catch
            {
                return false;
            }
        }

        #endregion

        public async Task<RespuestaAutenticacion> Login(CredencialesUsuario credencialesUsuario)
        {
            using var dbContext = await _dbContextFactory.CreateDbContextAsync();
            dbContext.Database.SetCommandTimeout(10);
            var respuestaAutenticacion = new RespuestaAutenticacion();

            try
            {
                if (string.IsNullOrWhiteSpace(credencialesUsuario?.Email) ||
                    string.IsNullOrWhiteSpace(credencialesUsuario?.Password))
                {
                    respuestaAutenticacion.Error = "Email y contraseña son requeridos";
                    return respuestaAutenticacion;
                }

                Console.WriteLine($"🔍 Intentando login: '{credencialesUsuario.Email}'");

                var usuario = await dbContext.Usuario
                    .AsNoTracking()
                    .Include(u => u.RolNavigation)
                    .Where(u => u.Email == credencialesUsuario.Email)
                    .Select(u => new UsuarioLoginDto
                    {
                        IdUsuario = u.UsuarioId,
                        PrimerNombre = u.PrimerNombre ?? "",
                        SegundoNombre = u.SegundoNombre ?? "",
                        PrimerApellido = u.PrimerApellido ?? "",
                        SegundoApellido = u.SegundoApellido ?? "",
                        Correo = u.Email ?? "",
                        Password = u.Password ?? "",
                        Rol = u.Rol,
                        RolTipo = u.RolNavigation != null ? u.RolNavigation.NombreRol : null
                    })
                    .FirstOrDefaultAsync();

                if (usuario == null)
                {
                    Console.WriteLine("❌ Usuario NO encontrado");
                    HashPassword("dummy_password_to_prevent_timing_attack");
                    respuestaAutenticacion.Error = "Credenciales incorrectas";
                    return respuestaAutenticacion;
                }

                Console.WriteLine($"✅ Usuario encontrado: {usuario.Correo}");
                Console.WriteLine($"🎭 Rol: {usuario.RolTipo ?? "Sin rol"}");

                if (!VerifyPassword(credencialesUsuario.Password, usuario.Password))
                {
                    Console.WriteLine("❌ Password NO coincide");
                    respuestaAutenticacion.Error = "Credenciales incorrectas";
                    return respuestaAutenticacion;
                }

                Console.WriteLine("✅ Login exitoso!");
                respuestaAutenticacion = ConstruirTokenOptimizado(usuario);
                return respuestaAutenticacion;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"💥 Error en Login: {ex.Message}");
                respuestaAutenticacion.Error = "Error interno del servidor";
                return respuestaAutenticacion;
            }
        }

        private RespuestaAutenticacion ConstruirTokenOptimizado(UsuarioLoginDto usuario)
        {
            try
            {
                var claims = new List<Claim>();

                // Email
                claims.Add(new Claim(ClaimTypes.Email, usuario.Correo));

                // Nombre completo
                string nombreCompleto = $"{usuario.PrimerNombre} {usuario.SegundoNombre} {usuario.PrimerApellido} {usuario.SegundoApellido}"
                    .Replace("  ", " ")
                    .Trim();

                claims.Add(new Claim(JwtRegisteredClaimNames.Name, nombreCompleto));
                claims.Add(new Claim("nombre", nombreCompleto));

                Console.WriteLine($"🔐 Token con nombre: '{nombreCompleto}'");

                // ID de usuario
                claims.Add(new Claim("idUsuario", usuario.IdUsuario.ToString()));
                claims.Add(new Claim(JwtRegisteredClaimNames.Sub, usuario.IdUsuario.ToString()));

                // Rol
                if (!string.IsNullOrEmpty(usuario.RolTipo))
                {
                    claims.Add(new Claim(ClaimTypes.Role, usuario.RolTipo));
                    claims.Add(new Claim("role", usuario.RolTipo));
                    Console.WriteLine($"🎭 Token con rol: '{usuario.RolTipo}'");
                }

                // ID de rol
                if (usuario.Rol.HasValue)
                {
                    claims.Add(new Claim("idRol", usuario.Rol.Value.ToString()));
                }

                if (string.IsNullOrEmpty(llavejwt))
                {
                    return new RespuestaAutenticacion { Error = "Error de configuración JWT" };
                }

                var keybuffer = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(llavejwt));
                DateTime expireTime = DateTime.UtcNow.AddHours(8);

                Console.WriteLine($"🕐 Token expira: {expireTime} UTC");

                var token = new JwtSecurityToken(
                    issuer: null,
                    audience: null,
                    claims: claims,
                    notBefore: DateTime.UtcNow,
                    expires: expireTime,
                    signingCredentials: new SigningCredentials(keybuffer, SecurityAlgorithms.HmacSha256)
                );

                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenString = tokenHandler.WriteToken(token);

                // 🔍 Verificar claims en el token generado
                var decodedToken = tokenHandler.ReadJwtToken(tokenString);
                Console.WriteLine("═══════════════════════════════════");
                Console.WriteLine("📋 CLAIMS EN EL TOKEN:");
                foreach (var claim in decodedToken.Claims)
                {
                    Console.WriteLine($"   {claim.Type}: {claim.Value}");
                }
                Console.WriteLine($"⏰ Expira: {decodedToken.ValidTo}");
                Console.WriteLine("═══════════════════════════════════");

                return new RespuestaAutenticacion
                {
                    Token = tokenString,
                    Expiration = expireTime,
                    Email = usuario.Correo
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"💥 Error al construir token: {ex.Message}");
                return new RespuestaAutenticacion { Error = "Error al generar token" };
            }
        }

        public async Task<RespuestaAutenticacion> RenovarToken(string email)
        {
            try
            {
                using var dbContext = await _dbContextFactory.CreateDbContextAsync();
                dbContext.Database.SetCommandTimeout(5);

                var usuario = await dbContext.Usuario
                    .AsNoTracking()
                    .Include(u => u.RolNavigation)
                    .Where(u => u.Email == email)
                    .Select(u => new UsuarioLoginDto
                    {
                        IdUsuario = u.UsuarioId,
                        PrimerNombre = u.PrimerNombre ?? "",
                        SegundoNombre = u.SegundoNombre ?? "",
                        PrimerApellido = u.PrimerApellido ?? "",
                        SegundoApellido = u.SegundoApellido ?? "",
                        Correo = u.Email ?? "",
                        Rol = u.Rol,
                        RolTipo = u.RolNavigation != null ? u.RolNavigation.NombreRol : null
                    })
                    .FirstOrDefaultAsync();

                if (usuario != null)
                {
                    return ConstruirTokenOptimizado(usuario);
                }

                return new RespuestaAutenticacion { Error = "Usuario no encontrado" };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en RenovarToken: {ex.Message}");
                return new RespuestaAutenticacion { Error = "Error interno" };
            }
        }
    }
}