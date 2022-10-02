using Microsoft.EntityFrameworkCore;

namespace Repositories;

public class ApplicationDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<EmployeePrivilege>().HasNoKey();
    }
}