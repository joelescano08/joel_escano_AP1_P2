using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace joel_escano_AP1_P2.Models
{
    public class AsignacionesPuntos
    {

        [Key]
        public int AsignacionId { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        public int EstudianteId { get; set; }

        public int TotalPuntos { get; set;  }





        //[Range(1,double.MaxValue, ErrorMessage ="El costo es obligatorio y tiene que ser mayor a 0")]



    }
}
