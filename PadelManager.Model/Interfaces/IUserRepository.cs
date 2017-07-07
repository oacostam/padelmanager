using System.Data.Entity;
using PadelManager.Core.Models;

namespace PadelManager.Core.Interfaces
{
    public interface IUserRepository : IUnitOfWork
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Reservation> Reservations { get; set; }
    }
}