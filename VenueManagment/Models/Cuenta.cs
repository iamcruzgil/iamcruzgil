using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VenueManagment.Models
{
    public class Cuenta
    {
        public int idCuenta { get; set; }
        [Required]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "El nombre no debe de tener más de 80 caracteres, ni menos de 3")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "El campo no debe de tener más de 80 caracteres, ni menos de 3")]
        [Display(Name = "Calle")]
        public string calle { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El área no debe de tener más de 20 caracteres, ni menos de 3")]
        [Display(Name = "Colonia")]
        public string colonia { get; set; }

        [Required]
        [Display(Name = "No. Interior")]
        public int noInt { get; set; }

        [Required]
        [Display(Name = "No. Exterior")]
        public int noExt { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El área no debe de tener más de 20 caracteres, ni menos de 3")]
        [Display(Name = "Ciudad")]
        public string ciudad { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El área no debe de tener más de 20 caracteres, ni menos de 3")]
        [Display(Name = "Estado")]
        public string estado { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El área no debe de tener más de 20 caracteres, ni menos de 3")]
        [Display(Name = "Pais")]
        public string pais { get; set; }

        [Required]
        [Display(Name = "CP")]
        public int cp { get; set; }

        [Display(Name = "WEB")]
        public string web { get; set; }

        [StringLength(80, MinimumLength = 3, ErrorMessage = "El campo no debe de tener más de 80 caracteres, ni menos de 3")]
        [Display(Name = "Descripcion")]
        public string descripcion { get; set; }

        [Display(Name = "Estatus")]
        public bool estatus { get; set; }
        [Required(ErrorMessage = "Seleccione el estado")]

        [Display(Name = "Contacto")]
        public int idContacto { get; set; }
        [Display(Name = "Contacto")]
        public virtual Contacto contacto { get; set; }

        [Display(Name = "Segmento")]
        public int idSegmento { get; set; }
        [Display(Name = "Segmento")]
        public virtual Segmento segmento { get; set; }

        [Display(Name = "Campana")]
        public int idCampana { get; set; }
        [Display(Name = "Campana")]
        public virtual Campana campana { get; set; }

        public virtual ICollection<RazonSocial> razonsocial { get; set; }
        //public virtual ICollection<Evento> evento { get; set; }

    }
}
