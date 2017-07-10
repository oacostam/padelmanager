#region

using System;
using System.Collections.Generic;
using System.Linq;
using PadelManager.Core.Exceptions;
using PadelManager.Core.Interfaces;
using PadelManager.Core.Models;
using PadelManager.Services.Common;
using PadelManager.Services.Interfaces;

#endregion

namespace PadelManager.Services.Implementations
{
    public class UserService : BaseService<User>, IUserService
    {
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        public Reservation CreateReservation(Reservation reservation)
        {
            //Only one reservation per day
            var reservationsCount =
                UnitOfWork.GetIDbSet<Reservation>()
                    .Count(r => r.User.Id == reservation.User.Id &&
                                r.ReservationDate.Date == reservation.ReservationDate.Date);
            if (reservationsCount > 0)
            {
                throw new PadelManagerException("No se puede realizar más de una reserva al día");
            }
            // No reservation if pending payments
            var unpayedReservations =
                UnitOfWork.GetIDbSet<Reservation>().Count(r => r.User.Id == reservation.User.Id &&
                                                               r.ReservationDate.Date < DateTime.Now.Date &&
                                                               !r.PayedAmmount.HasValue);
            if (unpayedReservations > 0)
            {
                throw new PadelManagerException(
                    "No se puede realizar una reserva sin haber pagado las anteriores pendientes.");
            }
            var result = UnitOfWork.GetIDbSet<Reservation>().Add(reservation);
            UnitOfWork.SetAdded(reservation);
            UnitOfWork.Complete();
            return result;
        }

        public IEnumerable<Reservation> GetUnpayedReservations(int userId)
        {
            return UnitOfWork.GetIDbSet<Reservation>().Where(r => r.User.Id == userId && !r.PayedAmmount.HasValue).ToList();
        }
    }
}