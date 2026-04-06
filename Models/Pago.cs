using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class Pago
{
    public int PagoId { get; set; }

    public int ArrendamientoId { get; set; }

    public decimal MontoPago { get; set; }

    public decimal MontoIva { get; set; }

    public decimal MontoTotal { get; set; }

    public int EstadoId { get; set; }

    public DateTime FechaPago { get; set; }

    public string? Referencia { get; set; }

    public string? Observaciones { get; set; }

    public int? UsuarioCreacion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public int IdTipoPago { get; set; }

    public virtual Arrendamiento Arrendamiento { get; set; } = null!;

    public virtual Estado Estado { get; set; } = null!;

    public virtual ICollection<Factura> Factura { get; set; } = new List<Factura>();

    public virtual ICollection<FacturaPago> FacturaPago { get; set; } = new List<FacturaPago>();

    public virtual TipoPago IdTipoPagoNavigation { get; set; } = null!;

    public virtual ICollection<TransaccionPago> TransaccionPago { get; set; } = new List<TransaccionPago>();

    public virtual Usuario? UsuarioCreacionNavigation { get; set; }
}
