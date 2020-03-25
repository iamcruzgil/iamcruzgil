using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace VenueManagment.Models
{
    public class FlujoIngreso
    {
        public int idFlujoIngreso { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre no debe de tener más de 50 caracteres, ni menos de 2")]
        [Display(Name ="Nombre")]
        public string nombre { get; set; }
        [Display(Name = "Estado")]
        public bool estado { get; set; }
        [Required(ErrorMessage ="Seleccione el tipo de Ingreso")]
        [Display(Name = "Tipo de Ingreso")]
        public int idTipoIngreso { get; set; }
        [Display(Name = "Tipo de Ingreso")]
        public virtual TipoIngreso tipoingreso { get; set; }
        public virtual ICollection<Espacio> espacio { get; set; }
    }
}
