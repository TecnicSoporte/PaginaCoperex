using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class Caracteristicas
{
    public int IdCaracteristicas { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Icono { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Areas> Areas { get; set; } = new List<Areas>();

    public virtual ICollection<AreasCaracteristicas> AreasCaracteristicas { get; set; } = new List<AreasCaracteristicas>();
}
