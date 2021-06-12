using southernfood.Data.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace southernfood.Datos.ViewModels
{
    public class ReporteViewModel
    {
        public ICollection<Mesero> meseros { get; set; }
        public ICollection<Cliente> clientes { get; set; }
        public ICollection<Factura> Facturas { get; set; }


        public decimal costsum(ICollection<Factura> facturas)
        {
            if (facturas != null)
            {
                var fact = facturas.Sum(f => f.DetalleFacturas.Sum(t => t.Valor));
                return fact;
            }
            return 0;
        }
    }
}
