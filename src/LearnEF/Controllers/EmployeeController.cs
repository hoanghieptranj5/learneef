using LearnEF.Logics.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Repositories.StoredProcedures;

namespace LearnEF.Controllers;

[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeLogic _employeeLogic;
    private readonly CustOrderHistSP _sp;

    public EmployeeController(IEmployeeLogic employeeLogic, CustOrderHistSP sp)
    {
        _employeeLogic = employeeLogic;
        _sp = sp;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetEmployeeById(int id)
    {
        var result = await _employeeLogic.GetSingleById(id);
        return Ok(result);
    }

    [HttpGet("test")]
    public async Task<IActionResult> GetTest(string customerNumber)
    {
        var result = await _sp.GetSingle(customerNumber);
        return Ok(result);
    }
}