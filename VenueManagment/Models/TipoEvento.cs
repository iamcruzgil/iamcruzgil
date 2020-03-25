using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VenueManagment.Models
{
    public class TipoEvento
    {
        public int idTipoEvento { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "El nombre no debe de tener más de 20 caracteres, ni menos de 2")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Estado")]
        public bool estado { get; set; }
        [Required(ErrorMessage = "Seleccione el estado")]

        [Display(Name = "Maestro Evento")]
        public int idMaestroEvento { get; set; }
        [Display(Name = "Maestro Evento")]
        public virtual MaestroEvento maestroevento { get; set; }
        //public virtual ICollection<Evento> evento { get; set; }
    }
}
