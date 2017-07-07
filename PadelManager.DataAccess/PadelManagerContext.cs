using System.Data.Entity;
using PadelManager.Core.Interfaces;
using PadelManager.Core.Models;

namespace PadelManager.DataAccess
{
    public class PadelManagerContext : DbContext, ICourtRepository, IUserRepository
    {
        public PadelManagerContext() : base("PadelManagerConnectionString")
        {
            
        }

        public int Complete()
        {
            return SaveChanges();
        }

        public IDbSet<Court> Courts { get; set; }
        public IDbSet<User> Users { get; set; }
        public IDbSet<Reservation> Reservations { get; set; }

    }
}