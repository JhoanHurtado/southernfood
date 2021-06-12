using System.ComponentModel.DataAnnotations;

namespace southernfood.Data.Models
{

    public class DetalleFactura
    {
        [Key]
        public int IdDetalleFactura { get; set; }

        public int NroFactura { get; set; }

        public int IdSupervisor { get; set; } 

        [Display(Name = "Nombre del plato"), Required(ErrorMessage = "El nombre del plato es requerido.")]
        public string Plato { get; set; }

        [Display(Name = "Costo del plato"), Required(ErrorMessage = "El costo del plato es requerido.")]
        public decimal Valor { get; set; }

        public virtual Factura Factura { get; set; }
        public virtual Supervisor Supervisor { get; set; }

    }
}
