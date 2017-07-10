#region

using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PadelManager.Core.Interfaces;
using PadelManager.Core.Models;
using PadelManager.Services.Implementations;

#endregion

namespace PadelManager.ServicesTests.Implementations
{
    [TestClass]
    public class CourtServiceTests
    {
        private CourtService courtService;

        [TestInitialize]
        public void CourtServiceTestsInitialize()
        {
            var courtRepo = new Mock<IUnitOfWork>();
            courtRepo.Setup(r => r.GetIDbSet<Court>()).Returns(new FakeDbSet<Court>(new Court
            {
                OpeningTime = new TimeSpan(9, 0, 0),
                ClosingTime = new TimeSpan(22, 0, 0),
                CreatedBy = "Mock",
                Id = 1,
                CreationdDate = new DateTime(1977, 2, 9),
                IsActive = true,
                UpdatedDate = DateTime.Now,
                UpdatedBy = "Mock",
                Name = "Test Court"
            }));
            courtService = new CourtService(courtRepo.Object);
        }

        [TestMethod]
        public void GetAllTest()
        {
            int total;
            var all = courtService.GetAll(1, 10, out total);
            Assert.AreEqual(total, all.Count());
            Assert.AreEqual(total, 1);
        }
    }
}