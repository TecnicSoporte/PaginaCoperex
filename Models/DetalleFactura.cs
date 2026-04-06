using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class DetalleFactura
{
    public int DetalleFacturaId { get; set; }

    public int FacturaId { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public decimal Subtotal { get; set; }

    public decimal PorcentajeIva { get; set; }

    public decimal MontoIva { get; set; }

    public decimal Total { get; set; }

    public virtual Factura Factura { get; set; } = null!;
}
