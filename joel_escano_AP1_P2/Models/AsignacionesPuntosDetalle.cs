using System.ComponentModel.DataAnnotations;

namespace joel_escano_AP1_P2.Models;

public class AsignacionesPuntosDetalle
{
    [Key]
    public int DetalleId { get; set; }

    public int AsignacionId { get; set; }

    public int TipoPuntosId { get; set; }

    public int CantidadPuntos { get; set; }

}
