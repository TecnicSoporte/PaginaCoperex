using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class DocumentoMemoria
{
    public int DocumentoId { get; set; }

    public int MemoriaLaboralId { get; set; }

    public string Titulo { get; set; } = null!;

    public string Url { get; set; } = null!;

    public int Orden { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public int? UsuarioCreacion { get; set; }

    public virtual MemoriaLaboral MemoriaLaboral { get; set; } = null!;

    public virtual Usuario? UsuarioCreacionNavigation { get; set; }
}
