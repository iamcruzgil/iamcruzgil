using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VenueManagment.Models
{
    public class Espacio
    {
        public int idEspacio { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre no debe de tener más de 50 caracteres, ni menos de 2")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El campo no debe de tener más de 50 caracteres, ni menos de 2")]
        [Display(Name = "Capacidad Max")]
        public string capacidadMaxima { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El área no debe de tener más de 50 caracteres, ni menos de 2")]
        [Display(Name = "Área")]
        public string area { get; set; }

        [Display(Name = "Combo")]
        public bool combo { get; set; }
        [Required(ErrorMessage = "Es combo ?")]

        [Display(Name = "Estado")]
        public bool estado { get; set; }
        [Required(ErrorMessage = "Seleccione el estado")]

        [Display(Name = "Flujo de Ingreso")]
        public int idFlujoIngreso { get; set; }
        [Display(Name = "Flujo de Ingreso")]
        public virtual FlujoIngreso flujoingreso { get; set; }
       

        [Display(Name = "Grupo de Esapcio")]
        public int idGrupoEspacio { get; set; }
        [Display(Name = "Grupo de Esapcio")]
        public virtual GrupoEspacio grupoespacio { get; set; }

        [Display(Name = "Venue")]
        public int idVenue { get; set; }
        [Display(Name = "Venue")]
        public virtual Venue venue { get; set; }
    }
}
