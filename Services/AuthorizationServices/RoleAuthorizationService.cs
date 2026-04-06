using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace PaginaWebCoperex.Services.AuthorizationServices
{
    public class RoleAuthorizationService : IRoleAuthorizationService
    {
        private readonly AuthenticationStateProvider _authStateProvider;

        public RoleAuthorizationService(AuthenticationStateProvider authStateProvider)
        {
            _authStateProvider = authStateProvider;
        }

        public async Task<bool> HasRoleAsync(string requiredRole)
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            if (!authState.User.Identity.IsAuthenticated)
                return false;

            // ✅ BUSCAR EN MÚLTIPLES TIPOS DE CLAIM
            var userRole = authState.User.FindFirst("role")?.Value ??
                          authState.User.FindFirst(ClaimTypes.Role)?.Value;

            Console.WriteLine($"🔍 HasRoleAsync - Rol del usuario: '{userRole}', Requiere: '{requiredRole}'");

            return string.Equals(userRole, requiredRole, StringComparison.OrdinalIgnoreCase);
        }

        public async Task<string> GetCurrentUserRoleAsync()
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            if (!authState.User.Identity?.IsAuthenticated ?? false)
            {
                Console.WriteLine("❌ Usuario no autenticado en GetCurrentUserRoleAsync");
                return string.Empty;
            }

            // ✅ BUSCAR EN MÚLTIPLES TIPOS DE CLAIM
            var role = authState.User.FindFirst("role")?.Value ??
                      authState.User.FindFirst(ClaimTypes.Role)?.Value ??
                      "";

            Console.WriteLine($"🎭 Rol actual del usuario: '{role}'");

            // 🔍 DEBUG: Mostrar todos los claims disponibles
            Console.WriteLine("═══════════════════════════════════");
            Console.WriteLine("📋 CLAIMS DISPONIBLES EN RoleAuthorizationService:");
            foreach (var claim in authState.User.Claims)
            {
                Console.WriteLine($"   {claim.Type}: {claim.Value}");
            }
            Console.WriteLine("═══════════════════════════════════");

            return role;
        }

        public async Task<bool> CanAccessPageAsync(string pageRole)
        {
            if (string.IsNullOrEmpty(pageRole))
                return true; // Sin restricción de rol

            // Soporte para múltiples roles separados por coma
            var requiredRoles = pageRole.Split(',')
                .Select(r => r.Trim())
                .Where(r => !string.IsNullOrEmpty(r))
                .ToArray();

            if (!requiredRoles.Any())
                return true;

            foreach (var role in requiredRoles)
            {
                if (await HasRoleAsync(role))
                    return true;
            }

            return false;
        }

        public async Task<List<string>> GetUserPermissionsAsync()
        {
            var userRole = await GetCurrentUserRoleAsync();

            Console.WriteLine($"🔐 Determinando permisos para rol: '{userRole}'");

            var permissions = userRole switch
            {
                "Administrador" => new List<string>
                {
                    "Encuestas"
                },
                "Operador" => new List<string>
                {
                    "carnets_feria"
                },
                "Coordinador de Feria" => new List<string>
                {
                    "espacios_feria",
                    "carnets_feria"
                },
                _ => new List<string>()
            };

            Console.WriteLine($"✅ Permisos asignados: [{string.Join(", ", permissions)}]");

            return permissions;
        }
    }
}