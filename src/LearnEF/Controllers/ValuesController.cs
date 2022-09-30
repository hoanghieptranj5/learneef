﻿using Microsoft.AspNetCore.Mvc;
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
    public IEnumerable<string> Get()
    {
        var result = _dbContext.Products.Select(x => x.ProductName).ToList();
        return result;
    }
    
    [HttpGet("populateData")]
    public IEnumerable<string> PopulateData()
    {
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