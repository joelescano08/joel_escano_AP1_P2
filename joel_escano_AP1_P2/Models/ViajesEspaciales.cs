using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace joel_escano_AP1_P2.Models
{
    public class ViajesEspaciales
    {

        [Key]
        public int ViajeId { get; set; }

        public DateTime FechaIda { get; set; } = DateTime.Now;
        public DateTime FechaRegreso { get; set; }


    }
}
