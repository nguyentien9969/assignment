using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Test.Data.Repositories.Interface;

namespace Test.Data.Repositories.Implement
{
    public class EntityDatabseTransaction : IDatabaseTransaction
    {

        private IDbContextTransaction _transaction;
        public EntityDatabseTransaction(DbContext dbContext)
        {
            _transaction = dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }

        public void RollBack()
        {
            _transaction.Rollback();
        }
    }
}
