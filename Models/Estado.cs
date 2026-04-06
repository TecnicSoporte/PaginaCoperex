using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class Estado
{
    public int EstadoId { get; set; }

    public string NombreEstado { get; set; } = null!;

    public string? DescripcionEstado { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Arrendamiento> Arrendamiento { get; set; } = new List<Arrendamiento>();

    public virtual ICollection<Cotizacion> Cotizacion { get; set; } = new List<Cotizacion>();

    public virtual ICollection<HistorialPostulacion> HistorialPostulacionEstadoAnteriorNavigation { get; set; } = new List<HistorialPostulacion>();

    public virtual ICollection<HistorialPostulacion> HistorialPostulacionEstadoNuevoNavigation { get; set; } = new List<HistorialPostulacion>();

    public virtual ICollection<Pago> Pago { get; set; } = new List<Pago>();

    public virtual ICollection<PlazaTrabajo> PlazaTrabajo { get; set; } = new List<PlazaTrabajo>();
}
