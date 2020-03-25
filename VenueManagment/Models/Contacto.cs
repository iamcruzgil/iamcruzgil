using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VenueManagment.Models
{
    public class Contacto
    {
        public int idContacto { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre no debe de tener más de 50 caracteres, ni menos de 3")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [StringLength(13, MinimumLength = 10, ErrorMessage = "El teléfono no debe de tener más de 13 caracteres, ni menos de 10")]
        [Display(Name = "Teléfono")]
        public string telefono { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El mail no debe de tener más de 50 caracteres, ni menos de 3")]
        [Display(Name = "E-Mail")]
        public string email { get; set; }

        [Display(Name = "Estado")]
        public bool estado { get; set; }

        public virtual ICollection<Cuenta> cuenta { get; set; }
        //public virtual ICollection<Evento> evento { get; set; }
    }
}
