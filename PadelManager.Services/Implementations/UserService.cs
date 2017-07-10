#region

using System;
using System.Collections.Generic;
using System.Linq;
using PadelManager.Core.Exceptions;
using PadelManager.Core.Interfaces;
using PadelManager.Core.Models;
using PadelManager.Services.Interfaces;

#endregion

namespace PadelManager.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Create(User entity)
        {
            unitOfWork.Users.Add(entity);
            unitOfWork.Complete();
        }

        public void Delete(User entity)
        {
            unitOfWork.Users.Remove(entity);
            unitOfWork.Complete();
        }

        public IEnumerable<User> GetAll(int page, int size, out int total)
        {
            total = unitOfWork.Users.Count();
            int skipRows = (page - 1) * size;
            return unitOfWork.Users.Skip(skipRows).Take(size).ToList();
        }

        public void Update(User entity)
        {
            unitOfWork.Users.Attach(entity);
            unitOfWork.Complete();
        }

        public User GetById(int id)
        {
            return unitOfWork.Users.First(u => u.Id == id);
        }

        public Reservation CreateReservation(Reservation reservation)
        {
            //Only one reservation per day
            var reservationsCount =
                unitOfWork.Reservations.Count(r => r.User.Id == reservation.User.Id &&  r.ReservationDate.Date == reservation.ReservationDate.Date );
            if (reservationsCount > 0)
            {
                throw new PadelManagerException("No se puede realizar más de una reserva al día");
            }
            // No reservation if pending payments
            var unpayedReservations =
                unitOfWork.Reservations.Count(r => r.User.Id == reservation.User.Id &&
                                                       r.ReservationDate.Date < DateTime.Now.Date &&
                                                       !r.PayedAmmount.HasValue);
            if (unpayedReservations > 0)
            {
                throw new PadelManagerException("No se puede realizar una reserva sin haber pagado las anteriores pendientes.");
            }
            var result = unitOfWork.Reservations.Add(reservation);
            unitOfWork.Complete();
            return result;
        }

        public IEnumerable<Reservation> GetUnpayedReservations(int userId)
        {
            return unitOfWork.Reservations.Where(r => r.User.Id == userId && !r.PayedAmmount.HasValue).ToList();
        }
    }
}