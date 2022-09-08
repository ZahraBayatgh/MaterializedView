using MaterializedView.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MaterializedView.Data
{
    public class ReadDbContext : DbContext
    {
        public ReadDbContext(DbContextOptions<ReadDbContext> options):base(options)
        {
            
        }

        public DbSet<OrderMaterializedView> OrderMaterializedView { get; set; }
    }
}
