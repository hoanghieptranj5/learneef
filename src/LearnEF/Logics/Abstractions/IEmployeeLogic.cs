using Repositories.DAL.UnitOfWork;
using Repositories.Models;

namespace LearnEF.Logics.Abstractions;

public interface IEmployeeLogic
{
    public IUnitOfWork UnitOfWork { get; }

    Task<Employee> GetSingleById(int id);
}