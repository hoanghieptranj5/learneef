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
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var result = from order in _dbContext.Orders
            join employee in _dbContext.Employees on order.EmployeeId equals employee.Id
            where employee.Id == id
            select new { employee.FirstName, order.OrderDetails };
        return Ok(result.ToList());
    }
}