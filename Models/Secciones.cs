using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class Secciones
{
    public int SeccionesId { get; set; }

    public string NombreSecciones { get; set; } = null!;

    public int DepartamentoId { get; set; }

    public virtual DepartamentoTrabajo Departamento { get; set; } = null!;

    public virtual ICollection<DepartamentoSeccion> DepartamentoSeccion { get; set; } = new List<DepartamentoSeccion>();

    public virtual ICollection<PlazaTrabajo> PlazaTrabajo { get; set; } = new List<PlazaTrabajo>();

    public virtual ICollection<Usuario> Usuario { get; set; } = new List<Usuario>();
}
