using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class CotizacionArea
{
    public int CotizacionAreaId { get; set; }

    public int CotizacionId { get; set; }

    public int AreaId { get; set; }

    public bool EsPrincipal { get; set; }

    public string? Observaciones { get; set; }

    public int? IdTarifario { get; set; }

    public int? CotizacionServicioId { get; set; }

    public virtual Areas Area { get; set; } = null!;

    public virtual Cotizacion Cotizacion { get; set; } = null!;

    public virtual Tarifario? IdTarifarioNavigation { get; set; }
}
