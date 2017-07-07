using System.Collections.Generic;
using PadelManager.Core.Models;
using PadelManager.Services.Common;

namespace PadelManager.Services.Interfaces
{
    public interface IUserService : IEntityService<User>
    {
        Reservation CreateReservation(Reservation reservation);

        IEnumerable<Reservation> GetUnpayedReservations(User user);
    }
}