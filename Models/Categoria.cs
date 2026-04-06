using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class Categoria
{
    public int CategoriaId { get; set; }

    public string NombreCategoria { get; set; } = null!;

    public string? DescripcionCategoria { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<ServicioAdicional> ServicioAdicional { get; set; } = new List<ServicioAdicional>();
}
