using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class TipoContrato
{
    public int TipoContratoId { get; set; }

    public string NombreTipoContrato { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual ICollection<PlazaTrabajo> PlazaTrabajo { get; set; } = new List<PlazaTrabajo>();
}
