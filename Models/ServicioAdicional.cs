using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class ServicioAdicional
{
    public int ServicioAdicionalId { get; set; }

    public string NombreServicio { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int Categoria { get; set; }

    public decimal Precio { get; set; }

    public string? UnidadMedida { get; set; }

    public bool RequiereCantidad { get; set; }

    public bool Activo { get; set; }

    public virtual Categoria CategoriaNavigation { get; set; } = null!;

    public virtual ICollection<CotizacionServicio> CotizacionServicio { get; set; } = new List<CotizacionServicio>();
}
