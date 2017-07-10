using System.Collections.Generic;
using PadelManager.Core.Models;

namespace PadelManager.Services.Interfaces
{
    public interface IUserService : IEntityService<User>
    {
        Reservation CreateReservation(Reservation reservation);

        IEnumerable<Reservation> GetUnpayedReservations(int userId);
    }
}