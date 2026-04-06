using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class HistorialCotizacion
{
    public int HistorialCotizacionId { get; set; }

    public int CotizacionId { get; set; }

    public int UsuarioId { get; set; }

    public string? CampoTipo { get; set; }

    public DateTime FechaAccion { get; set; }

    public virtual Cotizacion Cotizacion { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
