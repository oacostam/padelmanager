#region

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PadelManager.Core.Exceptions;
using PadelManager.Core.Interfaces;
using PadelManager.Core.Models;
using PadelManager.Services.Implementations;

#endregion

namespace PadelManager.ServicesTests.Implementations
{
    [TestClass]
    public class UserServiceTests
    {
        private UserService userService;


        [TestInitialize]
        public void UserServiceTestsInitialize()
        {
            var userRepo = new Mock<IUnitOfWork>();
            userRepo.Setup(r => r.Users).Returns(new FakeDbSet<User>(new User
            {
                Address = "Address 1",
                CreatedBy = "Mock",
                Id = 1,
                CreationdDate = new DateTime(1977, 2, 9),
                IsActive = true,
                UserName = "oacostam",
                UpdatedDate = DateTime.Now,
                Password = Guid.NewGuid().ToString(),
                UpdatedBy = "Mock"
            }));
            userRepo.Setup(r => r.Reservations).Returns(new FakeDbSet<Reservation>());
            userService = new UserService(userRepo.Object);
        }

        [TestMethod]
        [ExpectedException(typeof(PadelManagerException))]
        public void NotMoreThanOneReservationPerDayTest()
        {
            var user = userService.GetById(1);
            Reservation reservation1 = new Reservation(){User = user, ReservationDate = new DateTime(2017, 1, 1)};
            userService.CreateReservation(reservation1);
            Reservation reservation2 = new Reservation() { User = user, ReservationDate = new DateTime(2017, 1, 1) };
            userService.CreateReservation(reservation2);
        }

        [TestMethod]
        [ExpectedException(typeof(PadelManagerException))]
        public void NotUnpayedReservationsTest()
        {
            var user = userService.GetById(1);
            Reservation reservation1 = new Reservation() { User = user, ReservationDate = new DateTime(2017, 1, 1) };
            userService.CreateReservation(reservation1);
            Reservation reservation2 = new Reservation() { User = user, ReservationDate = new DateTime(2017, 10, 1) };
            userService.CreateReservation(reservation2);
        }
    }
}