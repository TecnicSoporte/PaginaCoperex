using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class Factura
{
    public int FacturaId { get; set; }

    public int ArrendamientoId { get; set; }

    public int? PagoId { get; set; }

    public string NombreEmisor { get; set; } = null!;

    public string Nitemisor { get; set; } = null!;

    public string? DireccionEmisor { get; set; }

    public string? NomineReceptor { get; set; }

    public string? Nitreceptor { get; set; }

    public string? DireccionReceptor { get; set; }

    public string? NumeroFactura { get; set; }

    public string? SerieFactura { get; set; }

    public string? UuidFel { get; set; }

    public decimal SubTotal { get; set; }

    public decimal MontoIva { get; set; }

    public decimal Total { get; set; }

    public string? EstadoFel { get; set; }

    public DateTime? FechaEmision { get; set; }

    public DateTime? FechaCertificacion { get; set; }

    public DateTime? FechaAnulacion { get; set; }

    public string? MotivoAnulacion { get; set; }

    public string? XmlFel { get; set; }

    public int? UsuarioCreacion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual Arrendamiento Arrendamiento { get; set; } = null!;

    public virtual ICollection<DetalleFactura> DetalleFactura { get; set; } = new List<DetalleFactura>();

    public virtual ICollection<FacturaPago> FacturaPago { get; set; } = new List<FacturaPago>();

    public virtual Pago? Pago { get; set; }

    public virtual Usuario? UsuarioCreacionNavigation { get; set; }
}
