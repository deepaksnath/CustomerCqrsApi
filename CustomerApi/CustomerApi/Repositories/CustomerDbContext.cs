using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Repositories
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Customer>()
            //        .Property(s => s.Id)
            //        .HasColumnName("Id")
            //        .IsRequired();
        }
    }
}
