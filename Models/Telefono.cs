using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class Telefono
{
    public int TelefonoId { get; set; }

    public int CodigoDePaisId { get; set; }

    public int NumeroTelefono { get; set; }

    public bool Activo { get; set; }

    public virtual CodigoPais CodigoDePais { get; set; } = null!;

    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
