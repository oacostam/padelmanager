#region

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using PadelManager.Core.Common;
using PadelManager.Core.Interfaces;

#endregion

namespace PadelManager.DataAccess
{
    public class PadelManagerContext : DbContext, IUnitOfWork
    {
        public PadelManagerContext() : base("PadelManagerConnectionString")
        {
        }


        public DbEntityEntry<T> EntityEntry<T>(T entity) where T : class, IEntity
        {
            return Entry(entity);
        }

        public int Complete()
        {
            return SaveChanges();
        }

        public IDbSet<T> GetIDbSet<T>() where T : class, IEntity
        {
            return Set<T>();
        }

        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        public void SetDeleted(object entity)
        {
            Entry(entity).State = EntityState.Deleted;
        }

        public void SetAdded(object entity)
        {
            Entry(entity).State = EntityState.Added;
        }
    }
}