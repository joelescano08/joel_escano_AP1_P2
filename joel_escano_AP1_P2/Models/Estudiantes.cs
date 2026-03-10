using Microsoft.AspNetCore.Http.Timeouts;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace joel_escano_AP1_P2.Models;

public class Estudiantes
{
    [Key]

    public int EstudianteId { get; set; }

    [Required(ErrorMessage ="Este campo es requerido")]
    public string Nombres { get; set; } = string.Empty;

    [Required(ErrorMessage ="Este campo es requerido")]
    public string Email { get; set; } = string.Empty;
    [Required()]
    public int Edad { get; set; }

    public int BalancePuntos { get; set; } = 0;
}
