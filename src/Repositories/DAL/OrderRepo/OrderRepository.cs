using Microsoft.Extensions.Logging;
using Repositories.DAL.GenericRepo;
using Repositories.Models;

namespace Repositories.DAL.OrderRepo;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(NorthwindContext context, ILogger logger) : base(context, logger)
    {
    }
}