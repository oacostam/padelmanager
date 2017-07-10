using System.Collections.Generic;
using PadelManager.Core.Common;

namespace PadelManager.Services.Interfaces
{
    public interface IEntityService<T> where T : IEntity
    {
        T Create(T entity);

        void Delete(T entity);

        IEnumerable<T> GetAll(int page, int size, out int total);

        T Update(T entity);

        T GetById(int id);

        T SetActive(int id, bool active);
    }
}