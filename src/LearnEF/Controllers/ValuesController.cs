using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Helpers;

namespace LearnEF.Controllers;

[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    private ApplicationDbContext _dbContext;
    private DbContextHelper _helper;

    public ValuesController(ApplicationDbContext dbContext, DbContextHelper helper)
    {
        _dbContext = dbContext;
        _helper = helper;
    }

    // GET api/values
    [HttpGet]
    public IEnumerable<string> Get()
    {
        var values = _dbContext.Books.Select(x => x.Title).ToList();
        return values;
    }
    
    [HttpGet("populateData")]
    public IEnumerable<string> PopulateData()
    {
        _helper.InsertData();
        return new string[] { "value1", "value2" };
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