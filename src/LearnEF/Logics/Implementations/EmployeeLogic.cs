using LearnEF.Logics.Abstractions;
using Repositories.DAL.UnitOfWork;
using Repositories.Models;

namespace LearnEF.Logics.Implementations;

public class EmployeeLogic : IEmployeeLogic
{
    public EmployeeLogic(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }

    public IUnitOfWork UnitOfWork { get; }
    
    public async Task<Employee> GetSingleById(int id)
    {
        var employee = await UnitOfWork.Employees.GetById(id);
        return employee;
    }
}