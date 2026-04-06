using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class TipoPago
{
    public int TipoPagoId { get; set; }

    public string NombreTipoPago { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual ICollection<Pago> Pago { get; set; } = new List<Pago>();
}
