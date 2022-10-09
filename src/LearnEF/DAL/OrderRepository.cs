using Repositories.Models;

namespace LearnEF.DAL;

public class OrderRepository : GenericRepository<Order>, IOrderRepository
{
    public OrderRepository(NorthwindContext context, ILogger logger) : base(context, logger)
    {
    }
}