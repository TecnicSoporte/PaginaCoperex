using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class AreaTarifario
{
    public int AreaTarifarioId { get; set; }

    public int IdArea { get; set; }

    public int IdTarifario { get; set; }

    public virtual Areas IdAreaNavigation { get; set; } = null!;

    public virtual Tarifario IdTarifarioNavigation { get; set; } = null!;
}
