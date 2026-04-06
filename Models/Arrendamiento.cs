using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class Arrendamiento
{
    public int ArrendamientoId { get; set; }

    public int CotizacionId { get; set; }

    public string NumeroContrato { get; set; } = null!;

    public DateTime FechaContrato { get; set; }

    public DateTime FechaInicioEvento { get; set; }

    public DateTime FechaFinEvento { get; set; }

    public DateTime? FechaInicioPremontaje { get; set; }

    public DateTime? FechaFinPremontaje { get; set; }

    public decimal MontoArrendamiento { get; set; }

    public decimal SubtotalServicios { get; set; }

    public decimal TotalDescuentos { get; set; }

    public decimal TotalRecargos { get; set; }

    public decimal MontoNeto { get; set; }

    public decimal PorcentajeIva { get; set; }

    public decimal MontoIva { get; set; }

    public decimal MontoTotal { get; set; }

    public int EstadoId { get; set; }

    public string? Observaciones { get; set; }

    public int? UsuarioCreacion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public int? UsuarioModificacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<AjusteArrendamiento> AjusteArrendamiento { get; set; } = new List<AjusteArrendamiento>();

    public virtual Cotizacion Cotizacion { get; set; } = null!;

    public virtual Estado Estado { get; set; } = null!;

    public virtual ICollection<Factura> Factura { get; set; } = new List<Factura>();

    public virtual ICollection<Pago> Pago { get; set; } = new List<Pago>();

    public virtual Usuario? UsuarioCreacionNavigation { get; set; }

    public virtual Usuario? UsuarioModificacionNavigation { get; set; }
}
