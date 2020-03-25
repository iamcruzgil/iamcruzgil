using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VenueManagment.Models
{
    public class DetalleEvento
    {
        public int idDetalle { get; set; }

        public int idEvento { get; set; }
        public virtual Evento evento { get; set; }

        public int idEspacio { get; set; }
        [Display(Name = "Espacio")]
        public virtual Espacio espacio { get; set; }

        [Required(ErrorMessage = "Seleccione el Estado")]
        [Display(Name = "Estado")]
        public bool estado { get; set; }

    }
}
