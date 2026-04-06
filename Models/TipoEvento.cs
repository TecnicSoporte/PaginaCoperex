using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class TipoEvento
{
    public int TipoEventoId { get; set; }

    public string NombreTipoEvento { get; set; } = null!;

    public string? DescripcionTipoEvento { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Cotizacion> Cotizacion { get; set; } = new List<Cotizacion>();
}
