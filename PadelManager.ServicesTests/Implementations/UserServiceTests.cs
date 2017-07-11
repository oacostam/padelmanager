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
            var dbContext = new Mock<IUnitOfWork>();
            dbContext.Setup(u => u.GetIDbSet<User>()).Returns(new FakeDbSet<User>(new User
            {
                Address = "Address 1",
                CreatedBy = "Mock",
                Id = 1,
                CreationdDate = new DateTime(1977, 2, 9),
                IsActive = true,
                UpdatedDate = DateTime.Now,
                UpdatedBy = "Mock"
            }));
            dbContext.Setup(r => r.GetIDbSet<Reservation>()).Returns(new FakeDbSet<Reservation>());
            userService = new UserService(dbContext.Object);
        }

        [TestMethod]
        public void CreateTest()
        {
            User user = new User
            {
                Address = "Address 1",
                CreatedBy = "Test",
                CreationdDate = DateTime.Now,
                IsActive = true,
                UpdatedBy = "Test",
                UpdatedDate = DateTime.Now
            };
            user = userService.Create(user);
            Assert.IsNotNull(user);
        }

        [TestMethod]
        [ExpectedException(typeof(PadelManagerException))]
        public void NotMoreThanOneReservationPerDayTest()
        {
            var user = userService.GetById(1);
            Reservation reservation1 = new Reservation {User = user, ReservationDate = new DateTime(2017, 1, 1)};
            userService.CreateReservation(reservation1);
            Reservation reservation2 = new Reservation {User = user, ReservationDate = new DateTime(2017, 1, 1)};
            userService.CreateReservation(reservation2);
        }

        [TestMethod]
        [ExpectedException(typeof(PadelManagerException))]
        public void NotUnpayedReservationsTest()
        {
            var user = userService.GetById(1);
            Reservation reservation1 = new Reservation {User = user, ReservationDate = new DateTime(2017, 1, 1)};
            userService.CreateReservation(reservation1);
            Reservation reservation2 = new Reservation {User = user, ReservationDate = new DateTime(2017, 10, 1)};
            userService.CreateReservation(reservation2);
        }
    }
}