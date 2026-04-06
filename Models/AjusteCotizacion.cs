using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class AjusteCotizacion
{
    public int AjusteCotizacionId { get; set; }

    public int CotizacionId { get; set; }

    public int TipoAjusteId { get; set; }

    public string TipoCalculo { get; set; } = null!;

    public decimal Valor { get; set; }

    public decimal MontoCalculado { get; set; }

    public string? Motivo { get; set; }

    public int? UsuarioCreacion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Cotizacion Cotizacion { get; set; } = null!;

    public virtual TipoAjuste TipoAjuste { get; set; } = null!;

    public virtual Usuario? UsuarioCreacionNavigation { get; set; }
}
