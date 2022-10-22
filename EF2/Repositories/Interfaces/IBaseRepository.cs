using System.Linq.Expressions;
using EF2.Models;

namespace EF2.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity<int>
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
        T Get(Expression<Func<T, bool>> predicate);
        T Create(T entity);
        T Update(T entity);
        bool Delete(T entity);
        int SaveChanges();
        IDatabaseTransaction DatabaseTransaction();
    }
}