using Microsoft.EntityFrameworkCore;
using Repositories.Models;
using Repositories.StoredProcedures.Models;

namespace Repositories.StoredProcedures;

public class CustOrderHistSP
{
    private readonly NorthwindContext _context;

    public CustOrderHistSP(NorthwindContext context)
    {
        _context = context;
    }

    public async Task<List<CustOrderHist>> GetSingle(string customerNumber)
    {
        var result = await _context.Set<CustOrderHist>()
            .FromSqlRaw($"call CustOrderHist(\"{customerNumber}\")")
            .ToListAsync();
        return result;
    }
}