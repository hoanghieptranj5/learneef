using Repositories.Models;

namespace LearnEF.DAL.IConfiguration;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly NorthwindContext _context;
    private readonly ILogger _logger;
    
    public IEmployeeRepository Employees { get; }
    public IOrderRepository Orders { get; }

    public UnitOfWork(NorthwindContext context, ILoggerFactory loggerFactory)
    {
        _context = context;
        _logger = loggerFactory.CreateLogger("logs");
        Employees = new EmployeeRepository(context, _logger);
        Orders = new OrderRepository(context, _logger);
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}