﻿    using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Test.Data.Repositories.Interface;

namespace Test.Data.Repositories.Implement
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DbSet<T> _dbSet;
        private readonly LibraryContext _context;

        public BaseRepository(LibraryContext context)
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

        public IDatabaseTransaction DatabaseTransaction()
        {
            return new EntityDatabseTransaction(_context);
        }

        public T? GetOne(Expression<Func<T, bool>>? predicate)
        {
            return predicate == null ? _dbSet.FirstOrDefault() : _dbSet.FirstOrDefault(predicate);
        }

        public virtual IEnumerable<T> GetAllWithPredicate(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public T Update(T entity)
        {
            return _dbSet.Update(entity).Entity;
        }
    }
}
