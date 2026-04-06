using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using PaginaWebCoperex.Components;
using PaginaWebCoperex.Models;
using PaginaWebCoperex.Services.AuthorizationServices;
using PaginaWebCoperex.Services.LoginServices;

var builder = WebApplication.CreateBuilder(args);

// ── Blazor ────────────────────────────────────────────────
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents(options => options.DetailedErrors = true);

builder.Services.AddCascadingAuthenticationState();

// ── Autenticación y autorización ─────────────────────────
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider =>
    provider.GetRequiredService<CustomAuthenticationStateProvider>());

builder.Services.AddScoped<IRoleAuthorizationService, RoleAuthorizationService>();
builder.Services.AddScoped<ILoginService, LoginService>();

// ── MudBlazor ────────────────────────────────────────────
builder.Services.AddMudServices();

// ── Base de datos (solo Factory, es suficiente) ───────────
builder.Services.AddDbContextFactory<PaginaWebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CitasCoperexCon")));

// ── HttpContext (necesario para servicios de auth) ────────
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// ── Pipeline HTTP ─────────────────────────────────────────
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();   // ← faltaba
app.UseAuthorization();    // ← faltaba

app.UseAntiforgery();

app.UseStaticFiles();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();