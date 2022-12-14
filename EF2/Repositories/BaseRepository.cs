using System.Linq.Expressions;
using EF2.Data;
using EF2.Models;
using EF2.Repositories;
using EF2.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Enitity_Framework.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity<int>
    {
        private readonly DbSet<T> _dbSet;
        private readonly ProductStoreContext _context;

        public BaseRepository(ProductStoreContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }
        public T Create(T entity)
        {
            return _dbSet.Add(entity).Entity;
        }

        public bool Delete(T entity)
        {
            _dbSet.Remove(entity);
            return true;
        }

        public T Get(Expression<Func<T, bool>>? predicate)
        {
            return predicate == null ? _dbSet.FirstOrDefault() : _dbSet.FirstOrDefault(predicate);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate)
        {
            return predicate == null ? _dbSet : _dbSet.Where(predicate);
        }

        public T Update(T entity)
        {
            return _dbSet.Update(entity).Entity;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public IDatabaseTransaction DatabaseTransaction()
        {
            return new EntityDatabaseTransaction(_context);
        }
    }
}