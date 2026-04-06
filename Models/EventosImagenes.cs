using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class EventosImagenes
{
    public int EventosImagenesId { get; set; }

    public int ImagenId { get; set; }

    public int EventoId { get; set; }

    public virtual Eventos Evento { get; set; } = null!;

    public virtual Imagenes Imagen { get; set; } = null!;
}
