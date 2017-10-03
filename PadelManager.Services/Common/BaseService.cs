#region

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PadelManager.Core.Common;
using PadelManager.Core.Interfaces;

#endregion

namespace PadelManager.Services.Common
{
    public abstract class BaseService<T> where T : class, IEntity
    {
        protected readonly IUnitOfWork UnitOfWork;

        protected BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public T Create(T entity)
        {
            entity = UnitOfWork.GetIDbSet<T>().Add(entity);
            UnitOfWork.SetAdded(entity);
            UnitOfWork.Complete();
            return entity;
        }

        public void Delete(T entity)
        {
            UnitOfWork.GetIDbSet<T>().Attach(entity);
            UnitOfWork.SetDeleted(entity);
            UnitOfWork.Complete();
        }

        public IEnumerable<T> GetAll(int page, int size, out int total)
        {
            total = UnitOfWork.GetIDbSet<T>().Count();
            int skipRows = (page - 1) * size;
            return UnitOfWork.GetIDbSet<T>().OrderBy(c => c.Id).Skip(skipRows).Take(size).ToList();
        }

        public T Update(T entity)
        {
            entity = UnitOfWork.GetIDbSet<T>().Attach(entity);
            UnitOfWork.SetModified(entity);
            UnitOfWork.Complete();
            return entity;
        }

        public T GetById(int id)
        {
            return UnitOfWork.GetIDbSet<T>().First(u => u.Id == id);
        }

        public T SetActive(int id, bool active)
        {
            var user = UnitOfWork.GetIDbSet<T>().First(u => u.Id == id);
            user.IsActive = active;
            UnitOfWork.EntityEntry(user).State = EntityState.Modified;
            UnitOfWork.Complete();
            return user;
        }
    }
}