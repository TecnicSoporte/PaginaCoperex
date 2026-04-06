using System;
using System.Collections.Generic;

namespace PaginaWebCoperex.Models;

public partial class TransaccionPago
{
    public int TransaccionPagoId { get; set; }

    public int PagoId { get; set; }

    public string Pasarela { get; set; } = null!;

    public string? TokenTransaccion { get; set; }

    public string? ReferenciaPasarela { get; set; }

    public string? CodigoRespuesta { get; set; }

    public string? MensajeRespuesta { get; set; }

    public string? DatosRespuesta { get; set; }

    public string? EstadoPasarela { get; set; }

    public DateTime FechaTransaccion { get; set; }

    public virtual Pago Pago { get; set; } = null!;
}
