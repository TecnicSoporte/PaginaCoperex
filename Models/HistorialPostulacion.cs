using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class HistorialPostulacion
{
    public int HistorialId { get; set; }

    public int PostulacionId { get; set; }

    public int PlazaTrabajo { get; set; }

    public int? EstadoAnterior { get; set; }

    public int EstadoNuevo { get; set; }

    public int? UsuarioAccion { get; set; }

    public DateTime FechaAccion { get; set; }

    public virtual Estado? EstadoAnteriorNavigation { get; set; }

    public virtual Estado EstadoNuevoNavigation { get; set; } = null!;

    public virtual PlazaTrabajo PlazaTrabajoNavigation { get; set; } = null!;

    public virtual Postulacion Postulacion { get; set; } = null!;

    public virtual Usuario? UsuarioAccionNavigation { get; set; }
}
