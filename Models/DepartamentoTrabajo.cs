using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class DepartamentoTrabajo
{
    public int DepartamentoId { get; set; }

    public string NombreDepartamento { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual ICollection<DepartamentoSeccion> DepartamentoSeccion { get; set; } = new List<DepartamentoSeccion>();

    public virtual ICollection<PlazaTrabajo> PlazaTrabajo { get; set; } = new List<PlazaTrabajo>();

    public virtual ICollection<Secciones> Secciones { get; set; } = new List<Secciones>();

    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
