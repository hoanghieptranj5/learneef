using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repositories.DAL.GenericRepo;
using Repositories.Models;

namespace Repositories.DAL.EmployeeRepo;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(NorthwindContext context, ILogger logger) : base(context, logger)
    {
    }

    public override async Task<bool> Delete(int id)
    {
        try
        {
            var exist = await dbSet.Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (exist == null)
            {
                return false;
            }

            dbSet.Remove(exist);

            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "{Repo} Delete function error", typeof(EmployeeRepository));
            return false;
        }
    }
}