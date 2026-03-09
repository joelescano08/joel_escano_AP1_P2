using System.ComponentModel.DataAnnotations;

namespace joel_escano_AP1_P2.Models;

public class AsignacionPuntosDetalle
{
    [Key]
    public int IdDetalle { get; set; }

    public int IdAsignacion { get; set; }

    public int TipoPuntosId { get; set; }

    public int CantidadPuntos { get; set; }

}
