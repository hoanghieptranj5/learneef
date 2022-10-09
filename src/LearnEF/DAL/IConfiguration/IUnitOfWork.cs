namespace LearnEF.DAL.IConfiguration;

public interface IUnitOfWork
{
    IEmployeeRepository Employees { get; }
    IOrderRepository Orders { get; }
    Task CompleteAsync();
}