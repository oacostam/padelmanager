using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using PadelManager.Core.Models;

namespace PadelManager.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {

        DbEntityEntry<T> EntityEntry<T>(T entity) where T : class;

        int Complete();

        IDbSet<User> Users { get; set; }

        IDbSet<Court> Courts { get; set; }

        IDbSet<Reservation> Reservations { get; set; }
    }
}