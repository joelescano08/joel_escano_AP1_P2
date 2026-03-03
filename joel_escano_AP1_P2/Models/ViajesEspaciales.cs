using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace joel_escano_AP1_P2.Models
{
    public class ViajesEspaciales
    {

        [Key]
        public int ViajeId { get; set; }

        [Range(1,double.MaxValue, ErrorMessage ="El costo es obligatorio y tiene que ser mayor a 0")]
        public double Costo { get; set; }
        public DateTime FechaIda { get; set; } = DateTime.Now;

        [Required(ErrorMessage ="La fecha de regreso es obligatoria")]
        public DateTime FechaRegreso { get; set; }


    }
}
