using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class RequisitosPlaza
{
    public int RequisitosPlazaId { get; set; }

    public int PlazaTrabajoId { get; set; }

    public int RequisitosId { get; set; }

    public virtual PlazaTrabajo PlazaTrabajo { get; set; } = null!;

    public virtual Requisitos Requisitos { get; set; } = null!;
}
