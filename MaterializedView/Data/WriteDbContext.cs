using MaterializedView.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MaterializedView.Data
{
    public class WriteDbContext : DbContext
    {
        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    Name = "Customer1",
                    BillingInformation = "001",
                    ShippingAddress = "Ab-Address",
                    Gender = Gender.Female,
                    Age = 30
                },
                new Customer
                {
                    Id = 2,
                    Name = "Customer2",
                    BillingInformation = "002",
                    ShippingAddress = "Cd-Address",
                    Gender = Gender.Male,
                    Age = 34
                }
                );
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
