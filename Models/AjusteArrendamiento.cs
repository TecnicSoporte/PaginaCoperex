using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class AjusteArrendamiento
{
    public int AjusteArrendamientoId { get; set; }

    public int ArrendamientoId { get; set; }

    public int TipoAjusteId { get; set; }

    public string TipoCalculo { get; set; } = null!;

    public decimal Valor { get; set; }

    public string? MontoCalculado { get; set; }

    public string? Motivo { get; set; }

    public int? UsuarioCreacion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Arrendamiento Arrendamiento { get; set; } = null!;

    public virtual TipoAjuste TipoAjuste { get; set; } = null!;

    public virtual Usuario? UsuarioCreacionNavigation { get; set; }
}
