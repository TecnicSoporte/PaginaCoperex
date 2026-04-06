using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class Eventos
{
    public int EventosId { get; set; }

    public string NombreEvento { get; set; } = null!;

    public string? DescripcionEvento { get; set; }

    public bool Activo { get; set; }

    public bool Interfer { get; set; }

    public string? ImagenesEvento { get; set; }

    public bool JornaSalud { get; set; }

    public bool EventoDestacado { get; set; }

    public int? UsuarioCreacion { get; set; }

    public virtual ICollection<EventosImagenes> EventosImagenes { get; set; } = new List<EventosImagenes>();

    public virtual Usuario? UsuarioCreacionNavigation { get; set; }
}
