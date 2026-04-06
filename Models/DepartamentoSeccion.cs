using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class DepartamentoSeccion
{
    public int DepartamentoSeccionId { get; set; }

    public int IdSeccionId { get; set; }

    public int IdDepartamento { get; set; }

    public virtual DepartamentoTrabajo IdDepartamentoNavigation { get; set; } = null!;

    public virtual Secciones IdSeccion { get; set; } = null!;
}
