using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using PadelManager.Core.Common;

namespace PadelManager.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        DbEntityEntry<T> EntityEntry<T>(T entity) where T : class, IEntity;

        int Complete();

        IDbSet<T> GetIDbSet<T>() where T : class, IEntity;

        void SetModified(object entity);

        void SetDeleted(object entity);

        void SetAdded(object entity);
    }
}