using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class Imagenes
{
    public int ImagenesId { get; set; }

    public string Imagen { get; set; } = null!;

    public bool EsPrincipal { get; set; }

    public int Orden { get; set; }

    public string? Icono { get; set; }

    public virtual ICollection<EventosImagenes> EventosImagenes { get; set; } = new List<EventosImagenes>();
}
