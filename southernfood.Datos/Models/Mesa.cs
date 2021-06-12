using southernfood.Datos;
using System.ComponentModel.DataAnnotations;

namespace southernfood.Data.Models
{
    public class Mesa
    {
        [Key]
        public int NroMesa { get; set; }

        [Required(ErrorMessage = "Nombre requerido Requerida!."), MinLength(8,ErrorMessage ="El nombre no puede tener menos de 5 caracteres"),MaxLength(40, ErrorMessage = "EL nombre no puede exceder los 45 caracteres")]
        public string Nombre { get; set; }

        public Reservada Reservada { get; set; }

        public int Puestos { get; set; }
    }
}
