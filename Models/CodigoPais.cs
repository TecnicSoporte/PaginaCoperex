using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class CodigoPais
{
    public int CodigoPaisId { get; set; }

    public string CodigoDePais { get; set; } = null!;

    public virtual ICollection<Telefono> Telefono { get; set; } = new List<Telefono>();
}
