using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VenueManagment.Models
{
    public class Evento
    {
        public int idEvento { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre no debe de tener más de 50 caracteres, ni menos de 2")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Fecha Inicio")]
        public DateTime fechaInicio { get; set; }

        [Required]
        [Display(Name = "Fecha Fin")]
        public DateTime fechaFin { get; set; }

        [Required(ErrorMessage = "Es dia completo")]
        [Display(Name = "Dia Completo")]
        public bool fullday { get; set; }

    }
}
