using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class Requisitos
{
    public int RequisitosId { get; set; }

    public string DescripcionRequisito { get; set; } = null!;

    public virtual ICollection<RequisitosPlaza> RequisitosPlaza { get; set; } = new List<RequisitosPlaza>();
}
