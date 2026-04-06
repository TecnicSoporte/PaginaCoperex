using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class Cotizacion
{
    public int CotizacionId { get; set; }

    public int? NombreSolicitante { get; set; }

    public string? NombreEmpresa { get; set; }

    public string? Nit { get; set; }

    public string? Email { get; set; }

    public int? Telefono { get; set; }

    public DateTime? FechaEventoInicio { get; set; }

    public DateTime? FechaEventoFin { get; set; }

    public DateTime? FechaInicioPremontaje { get; set; }

    public DateTime? FechaFinPremontaje { get; set; }

    public int? NumeroAsistentes { get; set; }

    public int? TipoEvento { get; set; }

    public string? Observaciones { get; set; }

    public decimal MontoEstimado { get; set; }

    public int Estado { get; set; }

    public int? UsuarioRevisor { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaRespuesta { get; set; }

    public bool Destacado { get; set; }

    public bool EventoInterno { get; set; }

    public virtual ICollection<AjusteCotizacion> AjusteCotizacion { get; set; } = new List<AjusteCotizacion>();

    public virtual ICollection<Arrendamiento> Arrendamiento { get; set; } = new List<Arrendamiento>();

    public virtual ICollection<CotizacionArea> CotizacionArea { get; set; } = new List<CotizacionArea>();

    public virtual ICollection<CotizacionServicio> CotizacionServicio { get; set; } = new List<CotizacionServicio>();

    public virtual Estado EstadoNavigation { get; set; } = null!;

    public virtual ICollection<HistorialCotizacion> HistorialCotizacion { get; set; } = new List<HistorialCotizacion>();

    public virtual Usuario? NombreSolicitanteNavigation { get; set; }

    public virtual TipoEvento? TipoEventoNavigation { get; set; }

    public virtual Usuario? UsuarioRevisorNavigation { get; set; }
}
