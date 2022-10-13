using Repositories.DAL.EmployeeRepo;
using Repositories.DAL.OrderRepo;

namespace Repositories.DAL.UnitOfWork;

public interface IUnitOfWork
{
    IEmployeeRepository Employees { get; }
    IOrderRepository Orders { get; }
    Task CompleteAsync();
}