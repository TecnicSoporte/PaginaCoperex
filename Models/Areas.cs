using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class Areas
{
    public int AreaId { get; set; }

    public string NombreArea { get; set; } = null!;

    public string? DescripcionArea { get; set; }

    public bool DisponibleArrendamiento { get; set; }

    public bool Activo { get; set; }

    public bool PatrimonioNacional { get; set; }

    public int? CaracteristicasId { get; set; }

    public int? AnoCreacion { get; set; }

    public string? NumeroRegistro { get; set; }

    public string? Author { get; set; }

    public string? EstiloArquitectura { get; set; }

    public virtual ICollection<AreaTarifario> AreaTarifario { get; set; } = new List<AreaTarifario>();

    public virtual ICollection<AreasCaracteristicas> AreasCaracteristicas { get; set; } = new List<AreasCaracteristicas>();

    public virtual Caracteristicas? Caracteristicas { get; set; }

    public virtual ICollection<CotizacionArea> CotizacionArea { get; set; } = new List<CotizacionArea>();
}
