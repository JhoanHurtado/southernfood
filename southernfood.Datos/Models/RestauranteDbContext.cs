using System.Data.Entity;

namespace southernfood.Data.Models
{
    public partial class RestauranteDbContext: DbContext 
    {
        public RestauranteDbContext()
            :base("name=RestConnectionsString")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {      
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Mesero> Meseros { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Supervisor> Supervisors { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<DetalleFactura> DetalleFacturas { get; set; }
    }
}
