using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace Repositories;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }
}