using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using PadelManager.Core.Interfaces;
using PadelManager.Core.Models;

namespace PadelManager.DataAccess
{
    public class PadelManagerContext : DbContext, IUnitOfWork
    {
        public PadelManagerContext() : base("PadelManagerConnectionString")
        {
        }


        public DbEntityEntry<T> EntityEntry<T>(T entity) where T : class
        {
            return Entry(entity);
        }

        public int Complete()
        {
            return SaveChanges();
        }

        public IDbSet<Court> Courts { get; set; }
        public IDbSet<User> Users { get; set; }
        public IDbSet<Reservation> Reservations { get; set; }

        protected override void Dispose(bool disposing)
        {
            Debug.WriteLine("Disposed");
            base.Dispose(disposing);
        }
    }
}