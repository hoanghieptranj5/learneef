using System.Security.Policy;

namespace Repositories.Helpers;

public class DbContextHelper
{
    public ApplicationDbContext DbContext { get; set; }

    public DbContextHelper(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }
}