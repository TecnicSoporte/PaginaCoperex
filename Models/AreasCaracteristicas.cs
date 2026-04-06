using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class AreasCaracteristicas
{
    public int AreasCaracteristicasId { get; set; }

    public int IdAreas { get; set; }

    public int IdCaracteristicas { get; set; }

    public virtual Areas IdAreasNavigation { get; set; } = null!;

    public virtual Caracteristicas IdCaracteristicasNavigation { get; set; } = null!;
}
