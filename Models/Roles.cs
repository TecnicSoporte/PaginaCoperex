using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class Roles
{
    public int RolesId { get; set; }

    public int UsuarioId { get; set; }

    public int RolId { get; set; }

    public bool Activo { get; set; }

    public virtual Rol Rol { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
