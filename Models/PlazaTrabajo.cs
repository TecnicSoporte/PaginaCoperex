using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class PlazaTrabajo
{
    public int PlazaTrabajoId { get; set; }

    public string TituloPlaza { get; set; } = null!;

    public int? SeccionId { get; set; }

    public int? DepartamentoId { get; set; }

    public int TipoContratoId { get; set; }

    public string? Descripcion { get; set; }

    public decimal? SalarioMin { get; set; }

    public decimal? SalarioMax { get; set; }

    public bool MostrarSalario { get; set; }

    public int NumeroVacantes { get; set; }

    public DateTime? FechaPublicacion { get; set; }

    public DateTime? FechaLimite { get; set; }

    public int Estado { get; set; }

    public bool Activo { get; set; }

    public int? UsuarioCreacion { get; set; }

    public DateTime FechaCreacion { get; set; }

    public virtual DepartamentoTrabajo? Departamento { get; set; }

    public virtual Estado EstadoNavigation { get; set; } = null!;

    public virtual ICollection<HistorialPostulacion> HistorialPostulacion { get; set; } = new List<HistorialPostulacion>();

    public virtual ICollection<Postulacion> Postulacion { get; set; } = new List<Postulacion>();

    public virtual ICollection<RequisitosPlaza> RequisitosPlaza { get; set; } = new List<RequisitosPlaza>();

    public virtual Secciones? Seccion { get; set; }

    public virtual TipoContrato TipoContrato { get; set; } = null!;

    public virtual Usuario? UsuarioCreacionNavigation { get; set; }
}
