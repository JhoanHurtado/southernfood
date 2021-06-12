using System.ComponentModel.DataAnnotations;

namespace southernfood.Data.Models
{
    public class Supervisor
    {
        [Key]
        public int IdSupervisor { get; set; }
        [Display(Name = "Nombre Completo"), Required(ErrorMessage = "Nombre es requerido!.")]
        public string Nombres { get; set; }
        [Display(Name = "Apellido Completo"), Required(ErrorMessage = "Apellido es requerido!.")]
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        [Required(ErrorMessage = "Antiguedad Requerida!.")]
        public int Antiguedad { get; set; }
    }
}
