using System.Collections.Generic;
using PadelManager.Core.Common;

namespace PadelManager.Services.Common
{
    public interface IEntityService<T> where T : IEntity
    {
        void Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll(int page, int size, out int total);
        void Update(T entity);
    }
}