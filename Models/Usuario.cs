using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string PrimerNombre { get; set; } = null!;

    public string? SegundoNombre { get; set; }

    public string? TercerNombre { get; set; }

    public string PrimerApellido { get; set; } = null!;

    public string? SegundoApellido { get; set; }

    public string? ApellidoCasada { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Dpi { get; set; }

    public string? Nit { get; set; }

    public DateOnly? FechaNacimiento { get; set; }

    public string? Fotografia { get; set; }

    public bool Activo { get; set; }

    public DateTime? FechaEliminacion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? Rol { get; set; }

    public int? TelefonoId { get; set; }

    public int? IdSeccion { get; set; }

    public int? IdDepartamento { get; set; }

    public virtual ICollection<AjusteArrendamiento> AjusteArrendamiento { get; set; } = new List<AjusteArrendamiento>();

    public virtual ICollection<AjusteCotizacion> AjusteCotizacion { get; set; } = new List<AjusteCotizacion>();

    public virtual ICollection<Arrendamiento> ArrendamientoUsuarioCreacionNavigation { get; set; } = new List<Arrendamiento>();

    public virtual ICollection<Arrendamiento> ArrendamientoUsuarioModificacionNavigation { get; set; } = new List<Arrendamiento>();

    public virtual ICollection<Cotizacion> CotizacionNombreSolicitanteNavigation { get; set; } = new List<Cotizacion>();

    public virtual ICollection<Cotizacion> CotizacionUsuarioRevisorNavigation { get; set; } = new List<Cotizacion>();

    public virtual ICollection<DocumentoLaip> DocumentoLaip { get; set; } = new List<DocumentoLaip>();

    public virtual ICollection<DocumentoMemoria> DocumentoMemoria { get; set; } = new List<DocumentoMemoria>();

    public virtual ICollection<Eventos> Eventos { get; set; } = new List<Eventos>();

    public virtual ICollection<Factura> Factura { get; set; } = new List<Factura>();

    public virtual ICollection<HistorialCotizacion> HistorialCotizacion { get; set; } = new List<HistorialCotizacion>();

    public virtual ICollection<HistorialPostulacion> HistorialPostulacion { get; set; } = new List<HistorialPostulacion>();

    public virtual DepartamentoTrabajo? IdDepartamentoNavigation { get; set; }

    public virtual Secciones? IdSeccionNavigation { get; set; }

    public virtual ICollection<MemoriaLaboral> MemoriaLaboral { get; set; } = new List<MemoriaLaboral>();

    public virtual ICollection<NumeralLaip> NumeralLaip { get; set; } = new List<NumeralLaip>();

    public virtual ICollection<Pago> Pago { get; set; } = new List<Pago>();

    public virtual ICollection<PlazaTrabajo> PlazaTrabajo { get; set; } = new List<PlazaTrabajo>();

    public virtual ICollection<Postulacion> Postulacion { get; set; } = new List<Postulacion>();

    public virtual Rol? RolNavigation { get; set; }

    public virtual ICollection<Roles> Roles { get; set; } = new List<Roles>();

    public virtual Telefono? Telefono { get; set; }
}
