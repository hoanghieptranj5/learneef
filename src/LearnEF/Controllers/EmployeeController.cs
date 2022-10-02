using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace LearnEF.Controllers;

[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly northwindContext _dbContext;

    public EmployeeController(northwindContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    // GET api/values
    [HttpGet]
    public IActionResult Get()
    {
        var result = _dbContext.Employees.ToList();
        return Ok(result);
    }
}