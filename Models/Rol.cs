using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class Rol
{
    public int RolId { get; set; }

    public string NombreRol { get; set; } = null!;

    public string? DescripcionRol { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Roles> Roles { get; set; } = new List<Roles>();

    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
