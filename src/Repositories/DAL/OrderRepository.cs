using Microsoft.Extensions.Logging;
using Repositories.Models;

namespace Repositories.DAL;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(NorthwindContext context, ILogger logger) : base(context, logger)
    {
    }
}