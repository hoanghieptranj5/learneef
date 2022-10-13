using LearnEF.Logics.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace LearnEF.Controllers;

[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeLogic _employeeLogic;

    public EmployeeController(IEmployeeLogic employeeLogic)
    {
        _employeeLogic = employeeLogic;
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetEmployeeById(int id)
    {
        var result = await _employeeLogic.GetSingleById(id);
        return Ok(result);
    }
}