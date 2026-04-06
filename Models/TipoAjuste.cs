using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class TipoAjuste
{
    public int TipoAjusteId { get; set; }

    public string NombreTipoAjuste { get; set; } = null!;

    public bool EsDescuento { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<AjusteArrendamiento> AjusteArrendamiento { get; set; } = new List<AjusteArrendamiento>();

    public virtual ICollection<AjusteCotizacion> AjusteCotizacion { get; set; } = new List<AjusteCotizacion>();
}
