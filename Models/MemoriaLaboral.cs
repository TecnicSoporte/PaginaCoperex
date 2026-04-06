using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class MemoriaLaboral
{
    public int MemoriaLaboralId { get; set; }

    public int Anio { get; set; }

    public string Titulo { get; set; } = null!;

    public bool EsMasReciente { get; set; }

    public string? ImagenPortadaUrl { get; set; }

    public DateTime? FechaPublicacion { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public int? UsuarioCreacion { get; set; }

    public virtual ICollection<DocumentoMemoria> DocumentoMemoria { get; set; } = new List<DocumentoMemoria>();

    public virtual Usuario? UsuarioCreacionNavigation { get; set; }
}
