using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VenueManagment.Models
{
    public class RazonSocial
    {
        public int idRazonSocial { get; set; }
        [Required]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "El nombre no debe de tener más de 80 caracteres, ni menos de 3")]
        [Display(Name = "Nombre")]
        public string nombre { get; set; }

        [Required]
        [StringLength(13, MinimumLength = 12, ErrorMessage = "El campo no debe de tener más de 13 caracteres, ni menos de 12")]
        [Display(Name = "RFC")]
        public string rfc { get; set; }

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

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El área no debe de tener más de 20 caracteres, ni menos de 3")]
        [Display(Name = "Metodo de Pago")]
        public string metodoPago { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El área no debe de tener más de 20 caracteres, ni menos de 3")]
        [Display(Name = "Uso CFDI")]
        public string usoCfdi { get; set; }

        [Display(Name = "Estatus")]
        public bool estatus { get; set; }
        [Required(ErrorMessage = "Seleccione el estado")]

        [Display(Name = "Cuenta")]
        public int idCuenta { get; set; }
        public virtual Cuenta cuenta { get; set; }
    }
}
