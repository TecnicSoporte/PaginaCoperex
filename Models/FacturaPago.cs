using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class FacturaPago
{
    public int FacturaPagoId { get; set; }

    public int FacturaId { get; set; }

    public int PagoId { get; set; }

    public virtual Factura Factura { get; set; } = null!;

    public virtual Pago Pago { get; set; } = null!;
}
