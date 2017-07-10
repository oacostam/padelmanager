#region

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using PadelManager.Core.Common;
using PadelManager.Core.Interfaces;
using PadelManager.Core.Models;

#endregion

namespace PadelManager.DataAccess
{
    public class PadelManagerContext : DbContext, IUnitOfWork
    {
        public PadelManagerContext() : base("PadelManagerConnectionString")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<PadelManagerContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Court>().ToTable("Courts");
            modelBuilder.Entity<Reservation>().ToTable("Reservations");
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