using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class CotizacionServicio
{
    public int CotizacionServicioId { get; set; }

    public int CotizacionId { get; set; }

    public int ServicioAdicionalId { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal SubTotal { get; set; }

    public string? Observaciones { get; set; }

    public virtual Cotizacion Cotizacion { get; set; } = null!;

    public virtual ServicioAdicional ServicioAdicional { get; set; } = null!;
}
