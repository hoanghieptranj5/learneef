using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace Repositories;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Order>()
            .HasOne<Employee>(e => e.Employee)
            .WithMany(p => p.Orders);
        
        modelBuilder.Entity<Order>()
            .HasOne<Customer>(e => e.Customer)
            .WithMany(p => p.Orders);
    }
}