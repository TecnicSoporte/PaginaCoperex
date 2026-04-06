using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class Postulacion
{
    public int PostulacionId { get; set; }

    public int PlazaTrabajoId { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? CvUrl { get; set; }

    public string? CartaMotivacion { get; set; }

    public string? EstadoPostulacion { get; set; }

    public string? NotasInternas { get; set; }

    public DateTime FechaPostulacion { get; set; }

    public DateTime? FechaEntrevista { get; set; }

    public int? UsuarioRevisor { get; set; }

    public virtual ICollection<HistorialPostulacion> HistorialPostulacion { get; set; } = new List<HistorialPostulacion>();

    public virtual PlazaTrabajo PlazaTrabajo { get; set; } = null!;

    public virtual Usuario? UsuarioRevisorNavigation { get; set; }
}
