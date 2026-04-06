using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class Tarifario
{
    public int TarifarioId { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Precio { get; set; }

    public int? AnoAprobacion { get; set; }

    public int Activo { get; set; }

    public decimal ValorDeposito { get; set; }

    public virtual ICollection<AreaTarifario> AreaTarifario { get; set; } = new List<AreaTarifario>();

    public virtual ICollection<CotizacionArea> CotizacionArea { get; set; } = new List<CotizacionArea>();
}
