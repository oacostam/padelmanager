#region

using System.Collections.Generic;
using System.Linq;
using PadelManager.Core.Interfaces;
using PadelManager.Core.Models;
using PadelManager.Services.Interfaces;

#endregion

namespace PadelManager.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void Create(User entity)
        {
            userRepository.Users.Add(entity);
            userRepository.Complete();
        }

        public void Delete(User entity)
        {
            userRepository.Users.Remove(entity);
            userRepository.Complete();
        }

        public IEnumerable<User> GetAll(int page, int size, out int total)
        {
            total = userRepository.Users.Count();
            int skipRows = (page - 1) * size;
            return userRepository.Users.Skip(skipRows).Take(size).ToList();
        }

        public void Update(User entity)
        {
            userRepository.Users.Attach(entity);
            userRepository.Complete();
        }

        public User GetById(int id)
        {
            return userRepository.Users.First(u => u.Id == id);
        }

        public Reservation CreateReservation(Reservation reservation)
        {
            //TODO Add bussines checks
            var result = userRepository.Reservations.Add(reservation);
            userRepository.Complete();
            return result;
        }

        public IEnumerable<Reservation> GetUnpayedReservations(User user)
        {
            return userRepository.Reservations.Where(r => r.ReservedToUser.Id == user.Id && !r.PayedAmmount.HasValue).ToList();
        }
    }
}