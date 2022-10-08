namespace LearnEF.DAL.IConfiguration;

public interface IUnitOfWork
{
    IEmployeeRepository Employees { get; }
    Task CompleteAsync();
}