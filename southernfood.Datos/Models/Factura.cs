using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace southernfood.Data.Models
{
    public class Factura
    {
        [Key]
        public int NroFactura { get; set; }
        [Display(Name = "Cliente")]
        
        public int IdCliente { get; set; }
        [Display(Name ="Mesa")]
        public int NroMesa { get; set; }
        [Display(Name = "Mesero")]

        public int IdMesero { get; set; }
        public DateTime Fecha { get; set; }
        [ForeignKey("IdCliente")]
        public virtual Cliente cliente { get; set; }
        public virtual Mesa Mesa { get; set; }
        public virtual Mesero Mesero { get; set; }
        public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; }
    }
}
