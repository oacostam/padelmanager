#region

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
            var userRepo = new Mock<IUserRepository>();
            userRepo.Setup(r => r.Users).Returns(new FakeDbSet<User>(new User
            {
                Address = "Address 1",
                CreatedBy = "Mock",
                Id = 1,
                CreatedDate = new DateTime(1977, 2, 9),
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
        public void UpdateTest()
        {
            var user = userService.GetById(1);
            Reservation reservation = new Reservation(){ReservedToUser = user};
            reservation = userService.CreateReservation(reservation);
            Assert.IsTrue(reservation.Id > 0);
        }
    }
}