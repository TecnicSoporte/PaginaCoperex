using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class NumeralLaip
{
    public int NumeralLaipid { get; set; }

    public int NumeroNumeral { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int Orden { get; set; }

    public bool Activo { get; set; }

    public int? UsuarioCreacion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual ICollection<DocumentoLaip> DocumentoLaip { get; set; } = new List<DocumentoLaip>();

    public virtual Usuario? UsuarioCreacionNavigation { get; set; }
}
