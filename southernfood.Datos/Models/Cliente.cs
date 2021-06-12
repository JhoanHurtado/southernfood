using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace southernfood.Data.Models
{

    public class Cliente
    {
        [Key, Required(ErrorMessage = "Identificacion requerid!.")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Identificacion { get; set; }
        [Display(Name = "Nombre Completo"), Required(ErrorMessage = "Nombre requerido!."),MaxLength(50,ErrorMessage ="El tamaño maximo es de 50 caracteres para el nombre")]
        public string Nombres { get; set; }

        [Display(Name = "Apellido Completo"), Required(ErrorMessage = "Apellido requerido!."), MaxLength(50, ErrorMessage = "El tamaño maximo es de 50 caracteres para el apellido")]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "Direccion requerido!.")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Telefono requerido!.")]
        public string Telefono { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
