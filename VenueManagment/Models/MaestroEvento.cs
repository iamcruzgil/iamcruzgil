using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VenueManagment.Models
{
    public class MaestroEvento
    {
        public int idMaestroEvento { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "El nombre no debe de tener más de 20 caracteres, ni menos de 2")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Estado")]
        public bool estado { get; set; }
        public virtual ICollection<TipoEvento> tipoevento { get; set; }
    }
}
