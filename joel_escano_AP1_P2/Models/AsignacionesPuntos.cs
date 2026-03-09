using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("AsignacionId")]
        public ICollection<AsignacionesPuntosDetalle> AsignacionesPuntosDetalle { get; set; } = new List<AsignacionesPuntosDetalle>();



    }
}
