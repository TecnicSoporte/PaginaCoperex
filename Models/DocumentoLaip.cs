using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class DocumentoLaip
{
    public int DocumentoLaipid { get; set; }

    public int IdnumeralLaip { get; set; }

    public string Titulo { get; set; } = null!;

    public string Url { get; set; } = null!;

    public int? Anio { get; set; }

    public int? Mes { get; set; }

    public bool EsNuevo { get; set; }

    public int Orden { get; set; }

    public DateTime? FechaPublicacion { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public int? UsuarioCreacion { get; set; }

    public virtual NumeralLaip IdnumeralLaipNavigation { get; set; } = null!;

    public virtual Usuario? UsuarioCreacionNavigation { get; set; }
}
