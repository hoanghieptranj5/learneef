using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Repositories.Models;

namespace LearnEF.DAL;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private NorthwindContext context;
    protected readonly DbSet<T> dbSet;

    protected ILogger _logger;

    protected GenericRepository(NorthwindContext context, ILogger logger)
    {
        this.context = context;
        dbSet = this.context.Set<T>();
        _logger = logger;
    }

    public virtual Task<IEnumerable<T>> All()
    {
        throw new NotImplementedException();
    }

    public virtual async Task<T> GetById(int id)
    {
        return await dbSet.FindAsync(id);
    }

    public virtual async Task<bool> Add(T entity)
    {
        await dbSet.AddAsync(entity);
        return true;
    }

    public virtual Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public virtual Task<bool> Upsert(T entity)
    {
        throw new NotImplementedException();
    }

    public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
    {
        return await dbSet.Where(predicate).ToListAsync();
    }
}