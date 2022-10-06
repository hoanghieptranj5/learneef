using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace LearnEF.Controllers;

[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly NorthwindContext _dbContext;

    public EmployeeController(NorthwindContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    // GET api/values
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = from order in _dbContext.Orders
            join employee in _dbContext.Employees on order.EmployeeId equals employee.Id
            where employee.Id == id
            select new { employee.FirstName, order.OrderDetails };
        return Ok(await result.ToListAsync());
    }
    
    // GET api/values
    [HttpGet("{id:int}/order")]
    public async Task<IActionResult> GetCustomerOrder(int id)
    {
        var result = from employee in _dbContext.Employees
            where employee.Id == id
            select new { employee.FirstName, employee.Orders };
        return Ok(await result.ToListAsync());
    }

    [HttpGet("{id:int}/something")]
    public async Task<IActionResult> GetSomething(int id)
    {
        var result = await _dbContext.Employees
            .Where(e => e.Id == id)
            .Include(e => e.Orders)
            .Select(x => x.Orders)
            .ToListAsync();

        return Ok(result);
    }
}