using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Helpers;

namespace LearnEF.Controllers;

[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public ValuesController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // GET api/values
    [HttpGet]
    public IActionResult Get()
    {
        var result = _dbContext.Products.ToList();
        return Ok(result);
    }
    
    [HttpGet("populateData")]
    public IActionResult PopulateData()
    {
        var result = _dbContext.Suppliers.ToList();
        return Ok(result);
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}