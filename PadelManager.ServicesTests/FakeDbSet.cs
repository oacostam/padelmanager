#region

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using PadelManager.Core.Common;

#endregion

namespace PadelManager.ServicesTests
{
    /// <summary>
    ///     This is an in-memory, List backed implementation of
    ///     Entity Framework's System.Data.Entity.IDbSet to use
    ///     for testing.
    /// </summary>
    /// <typeparam name="T">The type of entity to store.</typeparam>
    public class FakeDbSet<T> : IDbSet<T> where T : AuditableEntity
    {
        private readonly List<T> data;

        public FakeDbSet()
        {
            data = new List<T>();
        }

        public FakeDbSet(params T[] entities)
        {
            data = new List<T>(entities);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return data.GetEnumerator();
        }

        public Expression Expression => Expression.Constant(data.AsQueryable());

        public Type ElementType => typeof(T);

        public IQueryProvider Provider => data.AsQueryable().Provider;

        public T Find(params object[] keyValues)
        {
            throw new NotImplementedException("Use Linq .SingleOrDefault()");
        }

        public T Add(T entity)
        {
            var max = data.Any() ? data.Max(e => e.Id) : 0;
            entity.Id = ++max;
            data.Add(entity);
            return entity;
        }

        public T Remove(T entity)
        {
            data.Remove(entity);
            return entity;
        }

        public T Attach(T entity)
        {
            data.Add(entity);
            return entity;
        }

        public T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        public ObservableCollection<T> Local => new ObservableCollection<T>(data);
    }
}