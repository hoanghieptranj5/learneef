using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace Repositories;

public class ApplicationDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }
}