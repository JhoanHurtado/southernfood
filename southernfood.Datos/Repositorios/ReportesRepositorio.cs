using southernfood.Data.Models;
using southernfood.Datos.Interface;
using southernfood.Datos.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace southernfood.Datos.Repositorios
{
    public class ReportesRepositorio : IReporteRepositorio
    {
        private RestauranteDbContext _dbContext = new RestauranteDbContext();

        public async Task<ReporteViewModel> consumidoPorCliente(decimal valor)
        {
            var clientes = await _dbContext.Clientes.ToListAsync();
            foreach (var item in clientes)
            {
                var facturas = item.Facturas.Where(f => (f.DetalleFacturas.Sum(i=>i.Valor) >= valor));
            }

            return new ReporteViewModel();
        }

        public async Task<ReporteViewModel> productoMasVendidoDelMes(DateTime mes)
        {
            var facturas = await _dbContext.DetalleFacturas.Where(f => f.Factura.Fecha.Month.Equals(mes.Month)).GroupBy(g=> g.Plato).ToListAsync();

            return new ReporteViewModel();
        }

        public async Task<ReporteViewModel> VendidoPorMeseros(DateTime fechaInicial, DateTime fechaFinal, ReporteViewModel reporteViewModel)
        {
            var meseros = await _dbContext.Meseros.ToListAsync();
            foreach (var item in meseros)
            {
                var facturas = item.Facturas.Where(f => (f.Fecha >= fechaInicial && f.Fecha <= fechaFinal));
            }
            
            return reporteViewModel;
        }
    }
}
